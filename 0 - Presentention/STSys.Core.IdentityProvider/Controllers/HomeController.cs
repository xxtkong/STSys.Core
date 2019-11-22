using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocelot.JWTAuthorizePolicy;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.IdentityProvider.APIExtensions;
using STSys.Core.IdentityProvider.Common;
using STSys.Core.IdentityProvider.Models;
using STSys.Core.Users.Abstractions.Entities;

namespace STSys.Core.IdentityProvider.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IClientStore _clientStore;
        private readonly IRepository<UsersEntities> _repository;
        private readonly PermissionRequirement _requirement;
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// 事件服务的接口
        /// </summary>
        private readonly IEventService _events;
        public HomeController(IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider, IClientStore clientStore, IRepository<UsersEntities> repository, IEventService events, PermissionRequirement permission, IHttpClientFactory httpClientFactory)
        {
            this._interaction = interaction;
            this._schemeProvider = schemeProvider;
            this._clientStore = clientStore;
            this._repository = repository;
            this._events = events;
            this._requirement = permission;
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);
            if (vm.IsExternalLoginOnly)
            {
                return RedirectToAction("Challenge", "External", new { provider = vm.ExternalLoginScheme, returnUrl });
            }
            return View(vm);
        }
        /// <summary>
        /// 自定义登录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            // 检查我们是否在授权请求的上下文中
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            // 用户点击了“取消”按钮
            if (button != "login")
            {
                if (context != null)
                {
                    await _interaction.GrantConsentAsync(context, ConsentResponse.Denied);
                    if (await _clientStore.IsPkceClientAsync(context.ClientId))
                    {
                        return View("Redirect", new RedirectViewModel { RedirectUrl = model.ReturnUrl });
                    }
                    return Redirect("~/");
                }
                else
                {
                    return Redirect("~/");
                }
            }
            if (ModelState.IsValid)
            {
                if (model.UserType == "1")
                {
                    var user = _repository.Find("select * from Users where Mobile = @mobile and Status = 0", new { mobile = model.Username });
                    if (user != null)
                    {
                        var encodepassword = Cryptographer.EncodePassword(model.Password, 1, user.Encrypt);
                        if (encodepassword.Equals(user.Password))
                        {
                            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id.ToString(), user.Mobile));
                            AuthenticationProperties props = null;
                            if (AccountOptions.AllowRememberLogin && model.RememberLogin)
                            {
                                props = new AuthenticationProperties
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
                                };
                            }
                            await HttpContext.SignInAsync(user.Id.ToString(), user.Mobile, props);
                            if (_interaction.IsValidReturnUrl(model.ReturnUrl) || Url.IsLocalUrl(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                            }
                            return Redirect("~/");
                        }
                    }
                    await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "无效用户名或密码"));
                    ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
                }
                else
                {
                    var user = _repository.Find("select * from Consultant where Mobile = @mobile and Status = 0", new { mobile = model.Username });
                }
               
            }
            return View();
        }
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                //这意味着短路UI并且仅触发一个外部IdP
                return new LoginViewModel
                {
                    EnableLocalLogin = false,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                    ExternalProviders = new ExternalProvider[] { new ExternalProvider { AuthenticationScheme = context.IdP } }
                };
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("logout")]
        public async Task<IActionResult> LogOut(string logoutId)
        {
            var logout = await _interaction.GetLogoutContextAsync(logoutId);
            await HttpContext.SignOutAsync();
            if (logout.PostLogoutRedirectUri != null)
            {
                return Redirect(logout.PostLogoutRedirectUri);
            }
            var refererUrl = Request.Headers["Referer"].ToString();
            return Redirect(refererUrl);


            //var vm = await BuildLogoutViewModelAsync(logoutId);
            //if (vm.ShowLogoutPrompt == false)
            //{
            //    return await Logout(vm);
            //}
            //return View(vm);


            //await HttpContext.SignOutAsync();
            //return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutInputModel model)
        {
            var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);
            if (User?.Identity.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync();
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }
            if (vm.TriggerExternalSignout)
            {
                string url = Url.Action("Logout", new { logoutId = vm.LogoutId });
                return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
            }

            return View("LoggedOut", vm);
        }
        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };
            if (User?.Identity.IsAuthenticated != true)
            {
                vm.ShowLogoutPrompt = false;
                return vm;
            }
            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                vm.ShowLogoutPrompt = false;
                return vm;
            }
            return vm;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            var logout = await _interaction.GetLogoutContextAsync(logoutId);
            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User?.Identity.IsAuthenticated == true)
            {
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(idp);
                    if (providerSupportsSignout)
                    {
                        if (vm.LogoutId == null)
                        {
                            vm.LogoutId = await _interaction.CreateLogoutContextAsync();
                        }

                        vm.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return vm;
        }
        //[AllowAnonymous]
        //[HttpPost("/authapi/login")]
        //public IActionResult Login(string username, string password)
        //{
        //    var user = _repository.Find("select * from Users where Mobile = @mobile and Status = 0", new { mobile = username });
        //    if (user != null)
        //    {
        //        var encodepassword = Cryptographer.EncodePassword(password, 1, user.Encrypt);
        //        if (encodepassword.Equals(user.Password))
        //        {
        //            //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
        //            var claims = new Claim[] { new Claim(ClaimTypes.Name, username),
        //                new Claim(ClaimTypes.Role,"1"),
        //                new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(new TimeSpan().TotalSeconds).ToString()) };
        //            //用户标识
        //            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
        //            identity.AddClaims(claims);
        //            var token = JwtToken.BuildJwtToken(claims, _requirement);
        //            return new JsonResult(token);
        //        }
        //        return new JsonResult(new
        //        {
        //            Status = false,
        //            Message = "用户名或密码出错"
        //        });
        //    }
        //    else
        //    {
        //        return new JsonResult(new
        //        {
        //            Status = false,
        //            Message = "认证失败"
        //        });
        //    }
        //}
    }
}

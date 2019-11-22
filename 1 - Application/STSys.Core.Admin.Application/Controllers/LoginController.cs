using Common.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Cache;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Admin.Application.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepository<ManagerEntities> _repository;
        private readonly IRepositoryEF<ManagerEntities> _repositoryEF;
        private readonly ILogger _logger;
        public LoginController(IRepository<ManagerEntities> repository, IRepositoryEF<ManagerEntities> repositoryEF, ILogger<LoginController> logger)
        {
            this._repository = repository;
            this._repositoryEF = repositoryEF;
            this._logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index(string returnUrl = "")
        {
            //_logger.LogError("错误日志1111111");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel viewModel, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                string sql = $"select * from Manager where Mobile = @mobile";
                var channel = _repository.Find(sql, new { @mobile = viewModel.UserName });
                if (channel == null)
                {
                    ModelState.AddModelError(viewModel.UserName, "用户名或密码错误");
                    return View(viewModel);
                }
                else
                {
                    if (channel.Status == 0)
                    {

                        var encrypt = channel.Encrypt;
                        var encodepassword = Cryptographer.EncodePassword(viewModel.Pwd, 1, encrypt);
                        if (channel.Password.Equals(encodepassword))
                        {
                            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                            claimsIdentity.AddClaims(new List<Claim>()
                            {
                                new Claim(ClaimTypes.Sid, channel.Id.ToString()),
                                new Claim(ClaimTypes.Name, channel.Mobile),
                                new Claim(ClaimTypes.Role, "Manager"),
                                new Claim(ClaimTypes.Uri,channel.PicUrl??""),
                                new Claim("UserName",channel.Name)
                            });
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties()
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                                AllowRefresh = true
                            });
                            if (!string.IsNullOrEmpty(returnUrl))
                                return Redirect(returnUrl);
                            CommonManager.CacheObj.RemoveCache("nav" + channel.Id.ToString());
                            return Redirect("/Main/Index");
                        }
                        else
                        {
                            ModelState.AddModelError(viewModel.UserName, "用户名或密码错误");
                            return View(viewModel);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(viewModel.UserName, "用户名或密码错误");
                        return View(viewModel);
                    }
                }
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login/Index");
        }
    }
}

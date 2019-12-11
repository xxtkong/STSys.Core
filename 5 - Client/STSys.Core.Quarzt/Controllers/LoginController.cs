using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Data.Jobs.Services;
using STSys.Core.Quarzt.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STSys.Core.Quarzt.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Index(LoginViewModel viewModel,string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            UsersService usersService = new UsersService();
            var user = usersService.Login(viewModel.UserName, viewModel.Pwd);
            if (user != null)
            {
                var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaims(new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "admin"),
                });

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    AllowRefresh = true
                });
                if(!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                return Redirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("Pwd", "请检查用户或者密码是否正确");
                return View(viewModel);
            }

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login/Index");
        }
    }
}

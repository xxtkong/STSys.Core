using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.IdentityProvider.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STSys.Core.IdentityProvider.Controllers
{
    public class RegistController : Controller
    {
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            return View();
        }
    }
}

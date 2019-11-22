using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Orders.Models;

namespace STSys.Core.Orders.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated)
            {
                return Content(name);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

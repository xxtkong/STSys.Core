using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using STSys.Core.Data.Jobs.Business.Manager;
using STSys.Core.Quarzt.Models;

namespace STSys.Core.Quarzt.Controllers
{
    public class HomeController : Controller
    {
        public readonly IOptions<SqlSugarDB> _options;
        public HomeController(IOptions<SqlSugarDB> options)
        {
            this._options = options;
        }
        public IActionResult Index()
        {
            var connnectString = _options.Value.connectionString;
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

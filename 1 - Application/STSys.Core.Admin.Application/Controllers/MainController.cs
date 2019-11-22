using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Controllers
{
    public class MainController:BaseContorller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

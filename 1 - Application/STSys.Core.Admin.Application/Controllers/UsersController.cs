using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Controllers
{
    public class UsersController : BaseContorller
    {
        public IActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            return View();
        }
    }
}

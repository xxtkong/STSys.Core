using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STSys.Core.UserCenter.Controllers
{
    public class UtilController : Controller
    {
        public ActionResult Aear()
        {
            return Content("北京");
        }
    }
}

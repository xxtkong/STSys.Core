using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using STSys.Core.UserCenter.Common;
using STSys.Core.UserCenter.Models;

namespace STSys.Core.UserCenter.Controllers
{

    public class HomeController : BaseController
    {
        [Authorize(Roles = "company")]
        public async Task<IActionResult> Index()
        {
            //用户中心首页加载
            var model = await ApiHelper.GetAsync<UsersHomeViewModel>("/api/Options/GetUsersHome?usersId=4538", await GetToken());
            var name = User.Identity.Name;
            //var claims = HttpContext.User.Claims;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

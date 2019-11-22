using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using STSys.Core.UserCenter.Common;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STSys.Core.UserCenter.Controllers
{

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;

            return View();
        }

        [HttpPost]
        [Route("Index")]
        [ValidateAntiForgeryToken()]
        public IActionResult Index(string username,string pwd)
        {
            ApiHelper.RestPost<string>("/authapi/login", new Parameter[] {
                new Parameter(){ Name ="username",Value = username },
                new Parameter(){ Name ="password",Value = pwd }
            });
            return View();
        }


        //public async Task<IActionResult> Main()
        //{
        //    var client = new HttpClient();
        //    var disco = await client.GetDiscoveryDocumentAsync("http://localhost:9000");
        //    var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //    {
        //        Address = disco.TokenEndpoint,
        //        ClientId = "TokenServer",
        //        ClientSecret = "secret",
        //        Scope = "api1"
        //    });
        //    client.SetBearerToken(tokenResponse.AccessToken);
        //    //访问授权API
        //    var response = await client.GetAsync("http://localhost:5000/api/Values");
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(response.StatusCode);
        //    }
        //    else
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //    }
        //    return View();
        //}

        public async Task<IActionResult> Main2()
        {
            //登录成功后获取token 
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:5000/api/Values");
            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }
    }
}

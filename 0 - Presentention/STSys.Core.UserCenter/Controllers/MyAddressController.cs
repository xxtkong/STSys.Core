using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Controllers
{
    [Authorize]
    public class MyAddressController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            //验证Token
            //var disco = await DiscoveryClient.GetAsync("http://localhost:9000");
            //var tokenClient = new TokenClient(disco.TokenEndpoint, "client2", "secret");
            //var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("wjk", "123");

            var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
            //获取Token
            var client = new HttpClient();
            var discoveryClient = new DiscoveryClient("http://localhost:9000");
            var doc = await discoveryClient.GetAsync();
            var userInfoClient = new UserInfoClient(doc.UserInfoEndpoint);
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            client.SetBearerToken(accessToken);
            var response1 = await client.GetAsync("http://localhost:9000/connect/userinfo");
            if (!response1.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "未授权");
                return View();
            }
            else
            {
                var content = await response1.Content.ReadAsStringAsync();

            }





            //var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
            //var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            ////调用接口
            ////实例化HttpClient
            //var client = new HttpClient();
            ////设置token
            //client.SetBearerToken(token);
            ////请求identity接口
            //var response = await client.GetAsync("http://localhost:5000/api/Values");
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response.StatusCode);
            //}
            //var content = await response.Content.ReadAsStringAsync();
            return View();
        }


    }
}

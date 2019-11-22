using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STSys.Core.UserCenter.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// 登陆用户手机号
        /// </summary>
        public string LoginUserMobile => User.Identity.Name;
        /// <summary>
        /// 登陆用户ID
        /// </summary>
        public int LoginUserId => int.Parse(string.IsNullOrEmpty(HttpContext.User.Claims.Where(i => i.Type == "sub").FirstOrDefault().Value) ? "0" : 
            HttpContext.User.Claims.Where(i => i.Type == "sub").FirstOrDefault().Value);
       
        ///////////////////////////////////////////////////////////////用户名、密码访问
        protected async Task<string> GetTokenByLogin()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:9000");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "stsys.usercenter", "secret");
            var username = HttpContext.User.Claims.FirstOrDefault(s => s.Type == "username").Value;
            var pwd = HttpContext.User.Claims.FirstOrDefault(s => s.Type == "password").Value;
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, pwd, "api1");
            return tokenResponse.AccessToken;
        }
        protected async Task<string> GetToken()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            return accessToken;
        }
       
    }


}

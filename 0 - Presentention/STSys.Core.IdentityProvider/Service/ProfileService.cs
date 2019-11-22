using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.Models;
using IdentityServer4.Services;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STSys.Core.IdentityProvider.Service
{
    /// <summary>
    /// 获取用户信息并返回给客户端
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepository<UsersEntities> _repository;
        public ProfileService(IHttpClientFactory httpClientFactory, IRepository<UsersEntities> repository)
        {
            _httpClientFactory = httpClientFactory;
            _repository = repository;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");
                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    //var client = _httpClientFactory.CreateClient();
                    //DiscoveryResponse disco = await client.GetDiscoveryDocumentAsync("http://localhost:9000");
                    //var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    //{
                    //    Address = disco.TokenEndpoint,
                    //    ClientId = "TokenServer",
                    //    ClientSecret = "secret",
                    //    Scope = "api1"
                    //});
                    //if (tokenResponse.IsError)
                    //    throw new Exception(tokenResponse.Error);
                    //client.SetBearerToken(tokenResponse.AccessToken);
                    ////根据User_Id获取user
                    //var response = await client.GetAsync("http://localhost:5001/api/values/" + long.Parse(userId.Value));
                    //var content = await response.Content.ReadAsStringAsync();
                    //User user = JsonConvert.DeserializeObject<User>(content);
                    // issue the claims for the user


                    //context.IssuedClaims = new Claim[] { new Claim(JwtClaimTypes.Role, "company"), new Claim("username", "18623505212") }.ToList();
                    
                    var users = _repository.Find(int.Parse(userId.Value));
                    if (users != null)
                    {
                        var claims = GetUserClaims(users);
                        context.IssuedClaims = claims.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }
        /// <summary>
        /// 获取或设置一个值，该值指示主题是否处于活动状态并且可以接收令牌。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }

        /// <summary>
        /// 这里就是查询数据库角色表，赋予角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Claim[] GetUserClaims(UsersEntities user)
        {
            var claims = new Claim[] { new Claim(JwtClaimTypes.Role, "company"), new Claim("username", user.Mobile), new Claim("password", user.Password) };
            return claims;
        }
    }
}

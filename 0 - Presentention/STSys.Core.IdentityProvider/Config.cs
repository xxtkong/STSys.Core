using AutoMapper.Configuration;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STSys.Core.IdentityProvider
{
    public class Config
    {
        private readonly IConfiguration _configuration;
        public Config(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #region old
        /// <summary>
        /// 添加对OpenID Connect的支持
        /// </summary>
        /// <returns></returns>
        //public static IEnumerable<IdentityResource> GetIdentityResources()
        //{
        //    var customProfile = new IdentityResource(
        //        name: "mvc.profile",
        //        displayName: "Mvc profile",
        //        claimTypes: new[] { "role" });
        //    return new List<IdentityResource>
        //    {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //        new IdentityResources.Email(),
        //        new IdentityResource("roles", "角色", new List<string>{ "role" }),
        //        customProfile
        //    };
        //}


        ///// <summary>
        ///// 那些客户端访问资源
        ///// </summary>
        ///// <returns></returns>
        //public static IEnumerable<Client> GetClients()
        //{
        //    // 客户端信息
        //    return new List<Client>
        //    {
        //        new Client
        //        {
        //            ClientId = "TokenServer",
        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets =
        //            {
        //                new Secret("secret".Sha256())
        //            },
        //            AllowedScopes = { "api1" },
        //            Claims= new List<Claim>(){new Claim("role","admin") },
        //            ClientClaimsPrefix = ""
        //        },
        //        new Client
        //        {
        //            ClientId = "stsys.core",
        //            //客户端访问方式：密码验证
        //            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
        //            //用于认证的密码加密方式
        //            ClientSecrets =
        //            {
        //                new Secret("secret".Sha256())
        //            },
        //            //客户端有权访问的范围
        //            AllowedScopes = { "api1",
        //                IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报403 forbidden错误
        //                IdentityServerConstants.StandardScopes.Profile
        //            },
        //            Claims= new List<Claim>(){new Claim("role", "company") }
        //            //AccessTokenLifetime = 3600, //AccessToken的过期时间， in seconds (defaults to 3600 seconds / 1 hour)
        //            //AbsoluteRefreshTokenLifetime = 60, //RefreshToken的最大过期时间，in seconds. Defaults to 2592000 seconds / 30 day
        //            //RefreshTokenUsage = TokenUsage.OneTimeOnly,   //默认状态，RefreshToken只能使用一次，使用一次之后旧的就不能使用了，只能使用新的RefreshToken
        //            //RefreshTokenUsage = TokenUsage.ReUse,   //可重复使用RefreshToken，RefreshToken，当然过期了就不能使用了
        //        },
        //        //mvc客户端 (openId connect)
        //        new Client
        //        {
        //            ClientId = "stmvc",
        //            ClientName = "stmvc Client",
        //            AllowedGrantTypes = GrantTypes.Hybrid,
        //            //关闭确认是否返回身份信息界面
        //            RequireConsent=false,
        //           // 登录成功后重定向地址
        //            RedirectUris = { "http://localhost:5001/signin-oidc" },
        //           //注销成功后的重定向地址
        //            PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },
        //             //用于认证的密码加密方式
        //            ClientSecrets =
        //            {
        //                new Secret("secret".Sha256())
        //            },
        //             //客户端有权访问的范围
        //            AllowedScopes = new List<string>
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                IdentityServerConstants.StandardScopes.Email,
        //                "roles",
        //                "api1",
        //                "mvc.profile"
        //            },
        //        },
        //        // JavaScript Client
        //        new Client
        //        {
        //            ClientId = "js",
        //            ClientName = "JavaScript Client",
        //            AllowedGrantTypes = GrantTypes.Code,
        //            RequirePkce = true,
        //            RequireClientSecret = false,
        //            RedirectUris =           { "http://localhost:5003/callback.html" },
        //            PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
        //            AllowedCorsOrigins =     { "http://localhost:5003" },
        //            AllowedScopes =
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                "api1"
        //            }
        //        }
        //    };
        //}
        #endregion

        /// <summary>
        /// 哪些User可以被这个AuthrizationServer识别并授权 当然这里是默认用户
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "10001",
                    Username = "edison@hotmail.com",
                    Password = "edisonpassword"
                },
                new TestUser
                {
                    SubjectId = "10002",
                    Username = "andy@hotmail.com",
                    Password = "andypassword"
                },
                new TestUser
                {
                    SubjectId = "10003",
                    Username = "leo@hotmail.com",
                    Password = "leopassword"
                }
            };
        }

        /// <summary>
        /// 定义那些API 使用 IdentityServer4
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "企业主用户中心API"){ UserClaims= new List<string>{ JwtClaimTypes.Role} },
                new ApiResource("api2", "服务顾问用户中心API",new List<string>(){ "role"})
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles", "角色", new List<string>{ JwtClaimTypes.Role }),
                new IdentityResource("username", "用户名", new List<string>{ "username" }),
                new IdentityResource("password", "password", new List<string>{ "password" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "stCompany",
                    ClientName = "企业主登录客户端",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent=false,
                    RedirectUris =
                    {
                        "http://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5001/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "username",
                        "password"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "stConsultant",
                    ClientName = "服务顾问登录客户端",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent=false,
                    RedirectUris =
                    {
                        "http://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5002/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "username",
                        "password"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "stOrders",
                    ClientName = "订单中心",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent=false,
                    RedirectUris =
                    {
                        "http://localhost:5005/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5005/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "username"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "stsys.usercenter",
                    ClientName = "用户中心API客户端",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //客户端有权访问的范围
                    AllowedScopes = { "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    Claims= new List<Claim>(){new Claim("role", "company") },
                    AccessTokenLifetime = 3600, //AccessToken的过期时间， in seconds (defaults to 3600 seconds / 1 hour)
                    AbsoluteRefreshTokenLifetime = 60, //RefreshToken的最大过期时间，in seconds. Defaults to 2592000 seconds / 30 day
                    RefreshTokenUsage = TokenUsage.OneTimeOnly   //默认状态，RefreshToken只能使用一次，使用一次之后旧的就不能使用了，只能使用新的RefreshToken
                    //RefreshTokenUsage = TokenUsage.ReUse,   //可重复使用RefreshToken，RefreshToken，当然过期了就不能使用了
                },
                new Client
                {
                    ClientId = "CompanyTokenServer",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequireConsent=false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "username"
                    },
                    Claims= new List<Claim>(){new Claim("role", "company") }
                },
                new Client
                {
                    ClientId = "ConsultantTokenServer",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" },
                    Claims= new List<Claim>(){new Claim("role", "consultant") }
                }
            };
        }
    }
}

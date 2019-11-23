using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Essensoft.AspNetCore.Payment.Alipay;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using STSys.Core.UserCenter.Models;

namespace STSys.Core.UserCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));

            // 引入支付宝支付 依赖注入
            services.AddAlipay(s => {
                s.AppId = "";
                s.AlipayPublicKey = "";
                s.AppPrivateKey = "";

            });
            //引入微信支付
            services.AddWeChatPay(s =>
            {
                s.AppId = "";
                s.Key = "";
                s.MchId = "";
                s.Secret = "";
            });


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.AccessDeniedPath = "/Authorization/AccessDenied";
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "http://localhost:9000/";
                options.RequireHttpsMetadata = false;
                options.ClientId = "stCompany";
                options.ResponseType = "code id_token";
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("roles");
                options.Scope.Add("username");
                //options.Scope.Add("password");
                options.Scope.Add("api1");
                options.SaveTokens = true;
                options.ClientSecret = "secret";
                options.GetClaimsFromUserInfoEndpoint = true;

                options.ClaimActions.Remove("nbf");
                options.ClaimActions.Remove("amr");

                options.ClaimActions.DeleteClaim("sid");
                options.ClaimActions.DeleteClaim("idp");
                options.ClaimActions.DeleteClaim("email");

                options.ClaimActions.MapUniqueJsonKey("role", "role");
                options.ClaimActions.MapUniqueJsonKey("username", "username");
                options.ClaimActions.MapUniqueJsonKey("password", "password");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "username",
                    RoleClaimType = JwtClaimTypes.Role
                };
            });

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})


            //.AddCookie("Cookies")
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.SignInScheme = "Cookies";
            //    //授权端服务地址
            //    options.Authority = "http://localhost:9000/";
            //    //是否https请求
            //    options.RequireHttpsMetadata = false;
            //    //客户端ID名称
            //    options.ClientId = "stmvc";
            //    options.ClientSecret = "secret";
            //    //返回的类型详解请 混合模式
            //    options.ResponseType = "code id_token";
            //    //添加自定义用户信息
            //    options.Scope.Clear();
            //    options.Scope.Add("openid");
            //    options.Scope.Add("profile");
            //    options.Scope.Add("email");
            //    options.Scope.Add("roles");
            //    //是否存储token
            //    options.SaveTokens = true;
            //    //用于设置在从令牌端点接收的id_token创建标识后，处理程序是否应转到用户信息端点

            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    //访问名称api
            //    options.Scope.Add("api1");
            //    //避免claims被默认过滤掉，如果不想让中间件过滤掉nbf和amr, 把nbf和amr从被过滤掉集合里移除。可以使用下面这个方方式:
            //    options.ClaimActions.Remove("nbf");
            //    options.ClaimActions.Remove("amr");
            //    options.ClaimActions.Remove("email");
            //    options.ClaimActions.Remove("role");
            //    //删除某些Claims
            //    options.ClaimActions.DeleteClaim("sid");
            //    options.ClaimActions.DeleteClaim("idp");

            //    options.ClaimActions.MapUniqueJsonKey("role", "role");

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = JwtClaimTypes.Subject,
            //        RoleClaimType = JwtClaimTypes.Role
            //    };
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //添加用户验证中间件
            app.UseAuthentication();
            //跨域
            app.UseHttpsRedirection().UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

      
    }
}

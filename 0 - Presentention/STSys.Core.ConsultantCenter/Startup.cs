using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Essensoft.AspNetCore.Payment.Alipay;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
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
using STSys.Core.ConsultantCenter.Models;

namespace STSys.Core.ConsultantCenter
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
                s.AppId = "2018061960415563";
                s.AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwp2VlZTLxIXW0eeSIA0V/WpKBlEkdMFTWvco0Sv62kZ/OQaMoJg9bU8XajU6lioctv1vYl2J3RL8//z5iXwof5fSU+uKMUOLA3cUm7T/979eecpYKgcST0RSz1FsM4E5z2KR0J9ZMGxE5R6Fk7eVrinadXQRFPxZTkjWKLZixBM4NSydDjYorU1wI0vPGBDJx4fqFRXYE1+/n69hnMLDiSbboIluhz+bPlKTvMg7aTGO729kMZSpiAfeILqDhmmhmHXnT9xn6YJHU5BrOOMNO7mzXpuIZ6BHqiC1v3UeaqEAhrsJPEmbvgM8pcGU1Yf2451BmTX32ze2+y/RUtA30QIDAQAB";
                s.AppPrivateKey = "MIIEowIBAAKCAQEAxcIq5pWcX+TXWqHkeluepPZeafghM2ykuW7dovbZJXmf1zxAyC3dxyw95lmKM3Rhbb9B+lbtZFuAbPRnL2wT1kFfc4qwEcWw/sPtip+6NM0BFz1erHpYOu7hmnbLh6iaL4Y9JB2kCPaAoVi9X8E2g+Y49JkOISPN5+ux9F2s8l7RKTzPvPRzjLEjf5CsniNRJulEwD7jFddiTlOGtfcnI5SWzaVGet1QUbBEQuNBCDyPauM9+rbLVz4+eztEkSSeRM6yfnXbJssyz7W6TXp7KqI1Y3sn1EVOrA4s2RmdTwt1BjkQgJuCgcx1BC1fB0z1qnht3D9n2eN6J4q3q2SMWwIDAQABAoIBAGP0eUSlGC3r9+GqdFZYGr6cfCoprXZVkojbfZESHb1wVRcwMDo93JwAQ6U7WrwZNemHwyxqZYDVMvtfKQxyHzCrSDiZP9crygNrOpRXmYF4oPWDImghSpk3BrbRFpyR3qTov9ySUsfo+CkVNlrAyPIwGlefSOH9O+TeX8r40iKKYABVKZYqOG9PlGbaLhMN7d05hTWjBLzIdPpMWSoxhV34eNLORmQd3xGNBwVFs+yHuSbgAB+aDNRcqyyByu0QB1C8HLqq0S7F4Y9fqPNnykcDQUtGDEAso0SrWHjSJXE6aOAwaYJzm1lHU5jFQimipPQOb7Mj6GcoP8HIXr603rECgYEA9M+KUVebNrMW9a/pErpFNgQ90DQ65NVuBe6DRtizBfXCvtVhLxVxX3x8KL33f+VzaUhtCS44fngWRZAW5KJ+ePreAUYIPDKSxIU9Hb57lmfxrNhH8Lq9BlCI/D/0NXSjLBzQFqTfWoXSSMPg+2lnVN5YcAXaXcu1+6XGJIWmoDMCgYEAzswVI25mYP+316cXkcAZ2qgyRap0o1RlPFuZWg0lOERxEkkQisbVuWzk13QpDcaRDzU1nPTJkhNRfgt+NoB9efZBPaM8oeLct2v+rAHHRoRvGmtJicp1DRwms9jAxASa45DfVlgPLNaq4aYsipNzJuazGAwj7JRCOthqpuSEmzkCgYEA8jEwofCNubvLhxyU9NYbCql/ja9eZG1R/8RLU5em5MqR88Gd97q7AsBhBN2LMZiKaSoh1OdJNLURM5itTVwEyyNE5vWlyAgwcwNtxzNfiRkkWt9NrLbRsqGSJBwROaE+nLGUnBJYdXHW6+39cjyA4dFmpMzlj82tKFyEfjVK90kCgYBXw9l8zg/5Ps4hYjLokqTmXdfoJS2XW+wTL7TnuQiA1ts+LXAt1bFDHuoIXq5FwG40DBsS3/jkW/qMCgiozONz7YVGyY6kDgoqdlUBX0fZr78PcVUme5wt0jLCxU0aY/Hwfr2qgXj/SKQBXGsu7OFEM0jy/cQJVeq92rd42SdGUQKBgEG8IQyVk3i3wR/PQ1PIYJTgZ0bhn/FFB95JUdup8Bu8uDMzann1nKsDaNwg62QLrvETn8HLVwwICDYEwYpyQwKFRmyb+Y8qgRIFLZWUJ+hZ3LcwvMMEV1deguTXkrXKvJ7KGyR2QX/n9a6/oRfm3JJJJE0XsvTupTE4IVheSfba";

            });
            //引入微信支付
            services.AddWeChatPay(s =>
            {
                s.AppId = "wx434ac3440b5b7642";
                s.Key = "5T1CzsbaRBvwVVcP5Zgpl3b1gCTBs5O0";
                s.MchId = "1503872371";
                s.Secret = "0452d5c683df768cc72e7e6eedb9fa3f";
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
                options.ClientId = "stConsultant";
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

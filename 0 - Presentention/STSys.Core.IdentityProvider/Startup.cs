using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.JWTAuthorizePolicy;
using STSys.Core.Data.Context;
using STSys.Core.Data.IoC;
using STSys.Core.IdentityProvider.Service;

namespace STSys.Core.IdentityProvider
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
            services.AddHttpClient();


            services.AddIdentityServer(opts =>
            {
                opts.UserInteraction = new UserInteractionOptions
                {
                    LoginUrl = "/login",
                    LogoutUrl = "/logout",
                    ErrorUrl = "/error"
                };
            })
            ////证书加密方式（开发环境和测试环境使用 Token提供私约和公约）
            .AddDeveloperSigningCredential()
            ////正式环境切换下面使用证书。。就不使用公钥与私钥了
            ////.AddSigningCredential(new X509Certificate2(Path.Combine(basePath,Configuration["Certificates:CerPath"]), Configuration["Certificates:Password"]))
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients())
            .AddResourceOwnerValidator<LoginValidator>()
            .AddProfileService<ProfileService>()
            ;
            services.AddAntiforgery(opts =>
            {
                opts.Cookie.Name = "_mk_x_c_token";
                opts.FormFieldName = "_mk_x_f_token";
                opts.HeaderName = "_mk_x_h_token";
            });
            services.AddDbContext<STSysContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddNativeInjectorBootStrapper()
            ;
            var audienceConfig = Configuration.GetSection("Audience");
            //注入OcelotJwtBearer
            services.AddJTokenBuild(audienceConfig["Issuer"], audienceConfig["Issuer"], audienceConfig["Secret"], "/api/denied");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            //services.AddHttpClient();
            //services.AddIdentityServer(opts =>
            //{
            //    opts.UserInteraction = new UserInteractionOptions
            //    {
            //        LoginUrl = "/login",
            //        LogoutUrl = "/logout",
            //        ErrorUrl = "/error"
            //    };
            //})
            ////证书加密方式（开发环境和测试环境使用 Token提供私约和公约）
            //.AddDeveloperSigningCredential()
            ////正式环境切换下面使用证书。。就不使用公钥与私钥了
            ////.AddSigningCredential(new X509Certificate2(Path.Combine(basePath,Configuration["Certificates:CerPath"]), Configuration["Certificates:Password"]))
            //.AddInMemoryIdentityResources(Config.GetIdentityResources())
            //.AddInMemoryApiResources(Config.GetApiResources())
            //.AddInMemoryClients(Config.GetClients())
            ////.AddTestUsers(Config.GetUsers().ToList()) //添加测试用户
            //.AddResourceOwnerValidator<LoginValidator>()
            //.AddProfileService<ProfileService>();
            //services.AddAntiforgery(opts =>
            //{
            //    opts.Cookie.Name = "_mk_x_c_token";
            //    opts.FormFieldName = "_mk_x_f_token";
            //    opts.HeaderName = "_mk_x_h_token";
            //});
            //services.AddDbContext<STSysContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddNativeInjectorBootStrapper()
            //;

            //var audienceConfig = Configuration.GetSection("Audience");
            ////注入OcelotJwtBearer
            //services.AddJTokenBuild(audienceConfig["Issuer"], audienceConfig["Issuer"], audienceConfig["Secret"], "/api/denied");
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using STSys.Core.Admin.Application.Extensions;
using STSys.Core.Data.Context;
using STSys.Core.Data.IoC;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Log;
using STSys.Core.MQMiddleware;


namespace STSys.Core.Admin
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(IConfiguration configuration,ILogger<Startup> logger)
        {
            Configuration = configuration;
            this._logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ///默认的数据库链接
            services.AddDefaultDbContext(Configuration);
            services.AddMongoDB(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<AssemblyOptions>(options => {
                options.DomainAssemblyName = new List<string>() {
                    "STSys.Core.Admin.Abstractions",
                    "STSys.Core.Users.Abstractions"
                };
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Login/Index";
            });
            services.AddOptions();
            services.AddAutoMapper(GetType().Assembly);
            services.AddAutoMapperSetup();
            services.AddNativeInjectorBootStrapper(Configuration);
            services.AddMemoryCache();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAntiforgery(opts =>
            {
                opts.Cookie.Name = "_mk_x_c_token";
                opts.FormFieldName = "_mk_x_f_token";
                opts.HeaderName = "_mk_x_h_token";
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
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
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            var repositoryMongoDB = (IRepositoryMongoDB<QueueInfo>)serviceProvider.GetService(typeof(IRepositoryMongoDB<QueueInfo>));

            loggerFactory.AddProvider(new STSysLoggerProvider(new STSysLoggerConfiguration
            {
                LogLevel = LogLevel.Error,
                Color = ConsoleColor.Blue,
                repositoryMongoDB = repositoryMongoDB
            }));

            //loggerFactory.AddProvider(new STSysLoggerProvider(new STSysLoggerConfiguration
            //{
            //    LogLevel = LogLevel.Debug,
            //    Color = ConsoleColor.Gray,
            //    repositoryMongoDB = repositoryMongoDB
            //}));
            app.UseMiddleware<LogMQMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}

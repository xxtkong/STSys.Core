using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
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
using STSys.Core.Data.Context;
using STSys.Core.Data.IoC;
using STSys.Core.UsersApi.Application;
using STSys.Core.UsersApi.Application.Authorization;
using STSys.Core.UsersApi.Application.Controllers;
using STSys.Core.UsersApi.Application.Extensions;

namespace STSys.Core.UsersApi
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


            //var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            services.AddSwaggerService("","", "STSys.Core.UsersApi.xml");
            //内存数据库
            //ConfigureInMemoryDatabases(services);
            //正式库
            ConfigureProductionServices(services);

            //services.AddAutoMapper(typeof(Program).Assembly);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //添加缓存
            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddNativeInjectorBootStrapper(Configuration);
            //Mapper.AssertConfigurationIsValid();
       

            //身份验证服务添加到DI并配置"Bearer"为默认方案
            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:9000/";//identifyServer服务地址
                options.RequireHttpsMetadata = false;//是否使用https
                options.ApiName = "api1";
            });
            services.AddAutoMapper(GetType().Assembly);
            services.AddAutoMapperSetup();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddApplicationPart(typeof(ValuesController).Assembly);
            //注册验证
            //services.AddMvcCore(option =>
            //{
            //    option.Filters.Add(new STAuthorizationFilter());
            //}).AddAuthorization().AddJsonFormatters();

        }

        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<STSysContext>(c => c.UseInMemoryDatabase("Default"));
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
           
            services.AddDbContext<STSysContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IMapper autoMapper)
        {
            //autoMapper.ConfigurationProvider.AssertConfigurationIsValid();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.AddSwaggerConfigure();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();

            

            app.UseMvc();
        }
    }
}

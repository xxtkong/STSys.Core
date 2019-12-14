using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using STSys.Core.Data.IoC;
using STSys.Core.Domain.Core.Common;

namespace STSys.Core.ProductApi
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
            services.AddSwaggerService("商品API", "商品API", "STSys.Core.ProductApi.xml");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //采用EF绑定数据库
            services.AddEFDefaultDbContext(Configuration);
            //绑定命名空间
            services.Configure<AssemblyOptions>(options => {
                options.DomainAssemblyName = new List<string>() {
                    "STSys.Core.Product.Abstractions",
                };
            });
            //注册基础IOC
            services.AddNativeInjectorBootStrapper(Configuration);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.AddSwaggerConfigure();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

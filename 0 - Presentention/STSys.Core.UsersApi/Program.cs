using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using STSys.Core.Cache;
using STSys.Core.Data.Context;
using STSys.Core.Domain.Core.Common;

namespace STSys.Core.UsersApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var core_env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
           .SetBasePath(Environment.CurrentDirectory)   //指定配置文件所在的目录
           .AddJsonFile($"appsettings.{(string.IsNullOrEmpty(core_env) ? core_env : core_env + ".")}json", optional: true, reloadOnChange: true)
           .Build();
            ConfigManagerConf.SetConfiguration(config);//Config配置文件注册
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var catalogContext = services.GetRequiredService<STSysContext>();
                    STSysContextSeed.SeedAsync(catalogContext, loggerFactory).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            };

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel()
                //.UseIISIntegration()
                //.UseUrls("http://localhost:5000")
                .UseStartup<Startup>();
    }
}

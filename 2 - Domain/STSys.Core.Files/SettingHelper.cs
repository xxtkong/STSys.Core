using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Repository.MongoDB;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Files
{
    public class SettingHelper
    {
        static SettingHelper()
        {
            //加载配置文件
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ProcessDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            //加载Ioc
            serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(Configuration)
                .AddScoped<DbConnectionFactory>()
                .AddScoped(typeof(IRepositoryMongoDB<>), typeof(RepositoryMongoDB<>))
                .BuildServiceProvider();
        }

        public static string ProcessDirectory
        {
            get
            {
#if NETSTANDARD1_3
                return AppContext.BaseDirectory;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }

        public static IConfigurationRoot Configuration { get; }
        public static ServiceProvider serviceProvider { get; }
    }
}

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.UsersApi.Application.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            var config =  AutoMapperConfig.RegisterMappings();
            //services.AddSingleton<IMapper>(new Mapper(config));
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());


        }
    }
}

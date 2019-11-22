using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.UsersApi.Application.Extensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile(new DomainToViewModelMappingProfile());
            //    cfg.AddProfile(new ViewModelToDomainMappingProfile());
            //});


            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}

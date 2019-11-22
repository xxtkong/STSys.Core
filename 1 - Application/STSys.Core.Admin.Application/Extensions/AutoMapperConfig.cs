using AutoMapper;
using STSys.Core.Admin.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Extensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}

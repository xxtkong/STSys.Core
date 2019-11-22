using AutoMapper;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ManagerEntities, ManagerViewModel>();
            CreateMap<ModuleEntity, ModuleViewModel > ();
            CreateMap<RoleEntity, RoleViewModel>(); 
            CreateMap<ModuleElementEntity, ModuleElementViewModel>();

        }
    }
}

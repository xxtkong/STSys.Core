using AutoMapper;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ManagerViewModel, ManagerEntities>();
            CreateMap<ModuleViewModel, ModuleEntity>();
            CreateMap<RoleViewModel, RoleEntity>();
            CreateMap<ModuleElementViewModel, ModuleElementEntity>();
        }
    }
}

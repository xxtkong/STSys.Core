using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Extensions
{
    public class ModuleComparer : IEqualityComparer<ModuleEntity>
    {
        public bool Equals(ModuleEntity x, ModuleEntity y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(ModuleEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}

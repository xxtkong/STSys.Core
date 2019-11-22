using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class LoginRoleDto
    {
        public ModuleEntity modules { get; set; }
        public ModuleElementEntity moduleElements { get; set; }
    }
}

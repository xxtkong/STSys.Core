using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.ViewComponents
{
    public class ModuleTree
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<Guid> Pid { get; set; }
        public short IsMenu { get; set; }
    }
}

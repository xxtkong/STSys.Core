using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class ModuleEntity: Entity
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public Guid? Pid { get; set; }
        public string PName { get; set; }
        public int Level { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public short IsMenu { get; set; }
    }
}

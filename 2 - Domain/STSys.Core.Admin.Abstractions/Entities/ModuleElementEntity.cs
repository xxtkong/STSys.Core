using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class ModuleElementEntity: Entity
    {
        public string DomId { get; set; }
        public string Name { get; set; }
        public string Script { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public Guid ModuleId { get; set; }
        public string URL { get; set; }
    }
}

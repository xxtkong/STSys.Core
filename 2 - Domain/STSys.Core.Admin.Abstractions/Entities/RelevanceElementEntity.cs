using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class RelevanceElementEntity : Entity
    {
        public string Description { get; set; }
        public string Key { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> OperateTime { get; set; }
        public Guid OperatorId { get; set; }
        public Guid RoleId { get; set; }
        public Guid ElementId { get; set; }
        public Guid ModuleId { get; set; }

        [ForeignKey("ElementId")]
        public virtual ModuleElementEntity ModuleElementEntity { get; set; }
        [ForeignKey("ModuleId")]
        public virtual ModuleEntity ModuleEntity { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleEntity RoleEntity { get; set; }

    }
}

using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class RelevanceRoleEntity : Entity
    {
        public Guid ManagerId { get; set; }
        public string key { get; set; }
        public Guid RoleId { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> OperateTime { get; set; }
        public Guid OperatorId { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleEntity RoleEntity { get; set; }
    }
}

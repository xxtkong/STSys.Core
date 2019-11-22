using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class RoleEntity : Entity
    {
        public string Name { get; set; }
        public int? Status { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

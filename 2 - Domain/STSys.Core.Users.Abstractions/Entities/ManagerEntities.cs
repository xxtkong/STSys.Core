using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Entities
{
    public class ManagerEntities : Entity
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> LastTime { get; set; }
        public string Encrypt { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PicUrl { get; set; }
        public string Content { get; set; }
    }
}

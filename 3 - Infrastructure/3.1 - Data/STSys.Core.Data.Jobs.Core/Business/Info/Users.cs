using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Jobs.Business.Info
{
    public class Users
    {
        public Nullable<int> Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> LastTime { get; set; }
        public string Encrypt { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
    }
}

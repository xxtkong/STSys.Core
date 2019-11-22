using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public partial class AccountBindInfoViewModel
    {
        public Nullable<int> Id { get; set; }
        public short UserType { get; set; }
        public Nullable<int> UserId { get; set; }
        public short AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string AccountPicUrl { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public string Mobile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public class UserHomeViewModel
    {
        public Nullable<int> Id { get; set; }
        public string UserName { get; set; }
        public string PicUrl { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public Nullable<decimal> Balance { get; set; }
        /// <summary>
        /// 红包
        /// </summary>
        public Nullable<decimal> RedEnvelopes { get; set; }
        /// <summary>
        /// 可优惠卷数量
        /// </summary>
        public Nullable<int> CouponNumber { get; set; }

    }
}

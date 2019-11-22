using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public class OrderNumberViewModel
    {
        /// <summary>
        /// 待付款
        /// </summary>
        public int dfNum { get; set; }
        /// <summary>
        /// 待签合同
        /// </summary>
        public int dqNum { get; set; }
        /// <summary>
        /// 服务中
        /// </summary>
        public int yqNum { get; set; }
        /// <summary>
        /// 待评价
        /// </summary>
        public int dpNum { get; set; }
    }
}

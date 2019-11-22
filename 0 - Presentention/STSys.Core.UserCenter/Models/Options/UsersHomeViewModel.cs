using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Models
{
    public class UsersHomeViewModel
    {
        /// <summary>
        /// 个人中心基本数据
        /// </summary>
        public UserHomeViewModel usersHome { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public OrderNumberViewModel orderNumberModel { get; set; }

        /// <summary>
        /// 我的订单只显示2条
        /// </summary>
        public IList<OrderDetailsViewModel> orderDetailsList { get; set; }

        /// <summary>
        /// 值得购买服务
        /// </summary>
        public IList<ProductViewModel> productList { get; set; }

    }
   
}

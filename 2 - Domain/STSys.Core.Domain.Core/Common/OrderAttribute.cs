using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.Core.Common
{
    [AttributeUsage(AttributeTargets.All)]
    public class OrderAttribute : Attribute
    {
        public OrderAttribute(string orderitem = "GmtCreate", string orderType = "desc")
        {
            this.orderitem = orderitem;
            this.orderType = orderType;
        }

        public string orderitem { get; set; }
        public string orderType { get; set; }
    }
}

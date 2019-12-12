using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    /// <summary>
    /// 负载均衡接口
    /// </summary>
    public interface ILoadBalancer
    {
        Task<string> GetServiceAsync(string serviceName);
    }
}

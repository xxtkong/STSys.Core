using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    /// <summary>
    /// 顺序依次调用服务列表中的服务器，也可以指定一个加权值，来增加某个服务器的调用次数。
    /// </summary>
    public class RoundRobinLoadBalancer : ILoadBalancer
    {
        private readonly IServiceDiscoveryProvider _sdProvider;
        public RoundRobinLoadBalancer(IServiceDiscoveryProvider sdProvider)
        {
            _sdProvider = sdProvider;
        }
        private readonly object _lock = new object();
        private int _index = 0;
        public async Task<string> GetServiceAsync(string serviceName)
        {
            var services = await _sdProvider.GetServicesAsync(serviceName);
            lock (_lock)
            {
                if (_index >= services.Count)
                {
                    _index = 0;
                }
                return services[_index++];
            }
        }
    }
}

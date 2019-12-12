using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    /// <summary>
    /// 随机取
    /// </summary>
    public class RandomLoadBalancer : ILoadBalancer
    {
        private readonly IServiceDiscoveryProvider _sdProvider;
        public RandomLoadBalancer(IServiceDiscoveryProvider sdProvider)
        {
            _sdProvider = sdProvider;
        }
        private Random _random = new Random();
        public async Task<string> GetServiceAsync(string serviceName)
        {
            var services = await _sdProvider.GetServicesAsync(serviceName);
            return services[_random.Next(services.Count)];
        }
    }
}

using Consul;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    /// <summary>
    /// 获取服务
    /// </summary>
    public class ConsulServiceProvider : IServiceDiscoveryProvider
    {
        private string consulAddres;
        public ConsulServiceProvider(string url)
        {
            consulAddres = url;
        }
        public async Task<List<string>> GetServicesAsync(string serviceName)
        {
            var consuleClient = new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(consulAddres);
            });
            var queryResult = await consuleClient.Health.Service(serviceName, string.Empty, true);
            while (queryResult.Response.Length == 0)
            {
                Console.WriteLine("No services found, wait 1s....");
                await Task.Delay(1000);
                queryResult = await consuleClient.Health.Service(serviceName, string.Empty, true);
            }
            var result = new List<string>();
            foreach (var serviceEntry in queryResult.Response)
                result.Add(serviceEntry.Service.Address + ":" + serviceEntry.Service.Port);
            return result;
        }
    }
}

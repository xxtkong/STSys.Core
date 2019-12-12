using STSys.Core.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.AspNetCore
{
    public class ServiceRegistry
    {
        private readonly IRegistryHost _registryHost;
        public ServiceRegistry(IRegistryHost registryHost)
        {
            _registryHost = registryHost;
        }
        public async Task<RegistryInformation> RegisterServiceAsync(string serviceName, string version, Uri uri, Uri healthCheckUri = null, IEnumerable<string> tags = null)
        {
            var registryInformation = await _registryHost.RegisterServiceAsync(serviceName, version, uri, healthCheckUri, tags);

            return registryInformation;
        }
        public async Task<bool> DeregisterServiceAsync(string serviceId)
        {
            return await _registryHost.DeregisterServiceAsync(serviceId);
        }
        /// <summary>
        /// 添加健康检查
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceId"></param>
        /// <param name="checkUri"></param>
        /// <param name="interval"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public async Task<string> AddHealthCheckAsync(string serviceName, string serviceId, Uri checkUri, TimeSpan? interval = null, string notes = null)
        {
            return await RegisterHealthCheckAsync(serviceName, serviceId, checkUri, interval, notes);
        }
        public async Task<string> RegisterHealthCheckAsync(string serviceName, string serviceId, Uri checkUri, TimeSpan? interval = null, string notes = null)
        {
            return await _registryHost.RegisterHealthCheckAsync(serviceName, serviceId, checkUri, interval, notes);
        }
        /// <summary>
        /// 移除健康检查
        /// </summary>
        /// <param name="checkId"></param>
        /// <returns></returns>
        public async Task<bool> DeregisterHealthCheckAsync(string checkId)
        {
            return await _registryHost.DeregisterHealthCheckAsync(checkId);
        }
    }
}

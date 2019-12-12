using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    public interface IServiceDiscoveryProvider
    {
        Task<List<string>> GetServicesAsync(string serviceName);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STSys.Core.ConsulClients
{
    /// <summary>
    /// 定时获取服务列表
    /// </summary>
    public class PollingConsulServiceProvider : IServiceDiscoveryProvider
    {
        private List<string> _services = new List<string>();
        private bool _polling;
        private string _consulAddres;
        public PollingConsulServiceProvider(string consulAddres,string serviceName)
        {
            _consulAddres = consulAddres;
            var _timer = new Timer(async _ =>
            {
                if (_polling)
                {
                    return;
                }
                _polling = true;
                await Poll(serviceName);
                _polling = false;

            }, null, 0, 1000);
        }

        public async Task<List<string>> GetServicesAsync(string serviceName)
        {
            if (_services.Count == 0) await Poll(serviceName);
            return _services;
        }

        

        private async Task Poll(string serviceName)
        {
            _services = await new ConsulServiceProvider(_consulAddres).GetServicesAsync(serviceName);
        }
    }
}

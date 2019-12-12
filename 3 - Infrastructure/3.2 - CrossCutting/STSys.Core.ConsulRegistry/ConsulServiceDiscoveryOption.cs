using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.ConsulRegistry
{
    public class ConsulServiceDiscoveryOption
    {
        public string ServiceName { get; set; }

        public string Version { get; set; }

        public ConsulRegistryHostConfiguration Consul { get; set; }

        public string HealthCheckTemplate { get; set; }

        public string[] Endpoints { get; set; }
    }
}

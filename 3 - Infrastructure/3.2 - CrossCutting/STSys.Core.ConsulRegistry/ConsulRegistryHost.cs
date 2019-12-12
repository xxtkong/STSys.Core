using Consul;
using STSys.Core.Extensions;
using STSys.Core.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.ConsulRegistry
{
    public class ConsulRegistryHost: IRegistryHost
    {
        private const string VERSION_PREFIX = "version-";
        private readonly ConsulClient _consul;
        private readonly ConsulRegistryHostConfiguration _configuration;
        public ConsulRegistryHost(ConsulRegistryHostConfiguration configuration = null)
        {
            _configuration = configuration;

            _consul = new ConsulClient(config =>
            {
                config.Address = new Uri(_configuration.HttpEndpoint);
                if (!string.IsNullOrEmpty(_configuration.Datacenter))
                {
                    config.Datacenter = _configuration.Datacenter;
                }
            });
        }

        public async Task<bool> DeregisterServiceAsync(string serviceId)
        {
            var writeResult = await _consul.Agent.ServiceDeregister(serviceId);
            bool isSuccess = writeResult.StatusCode == HttpStatusCode.OK;
            string success = isSuccess ? "succeeded" : "failed";
            return isSuccess;
        }

       
        public async Task<RegistryInformation> RegisterServiceAsync(string serviceName, string version, Uri uri, Uri healthCheckUri = null, IEnumerable<string> tags = null)
        {
            var serviceId = GetServiceId(serviceName, uri);
            string check = healthCheckUri?.ToString() ?? $"{uri}".TrimEnd('/') + "/status";

            string versionLabel = $"{VERSION_PREFIX}{version}";
            var tagList = (tags ?? Enumerable.Empty<string>()).ToList();
            tagList.Add(versionLabel);

            var registration = new AgentServiceRegistration
            {
                ID = serviceId,
                Name = serviceName,
                Tags = tagList.ToArray(),
                Address = uri.Host,
                Port = uri.Port,
                Check = new AgentServiceCheck { HTTP = check, Interval = TimeSpan.FromSeconds(2) }
            };

            await _consul.Agent.ServiceRegister(registration);

            return new RegistryInformation
            {
                Name = registration.Name,
                Id = registration.ID,
                Address = registration.Address,
                Port = registration.Port,
                Version = version,
                Tags = tagList
            };
        }

        private string GetServiceId(string serviceName, Uri uri)
        {
            return $"{serviceName}_{uri.Host.Replace(".", "_")}_{uri.Port}";
        }

        public async Task<string> RegisterHealthCheckAsync(string serviceName, string serviceId, Uri checkUri, TimeSpan? interval = null, string notes = null)
        {
            if (checkUri == null)
            {
                throw new ArgumentNullException(nameof(checkUri));
            }

            var checkId = GetCheckId(serviceId, checkUri);
            var checkRegistration = new AgentCheckRegistration
            {
                ID = checkId,
                Name = serviceName,
                Notes = notes,
                ServiceID = serviceId,
                HTTP = checkUri.ToString(),
                Interval = interval
            };
            var writeResult = await _consul.Agent.CheckRegister(checkRegistration);
            bool isSuccess = writeResult.StatusCode == HttpStatusCode.OK;
            string success = isSuccess ? "succeeded" : "failed";

            return checkId;
        }
        private string GetCheckId(string serviceId, Uri uri)
        {
            return $"{serviceId}_{uri.GetPath().Replace("/", "")}";
        }
        public async Task<bool> DeregisterHealthCheckAsync(string checkId)
        {
            var writeResult = await _consul.Agent.CheckDeregister(checkId);
            bool isSuccess = writeResult.StatusCode == HttpStatusCode.OK;
            string success = isSuccess ? "succeeded" : "failed";
            return isSuccess;
        }
    }
}

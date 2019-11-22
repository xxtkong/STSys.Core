using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Common
{
    public class ConfigHelp
    {
        private string _API;
        private readonly IConfiguration _configuration;
        public ConfigHelp(IConfiguration configuration)
        {
            _configuration = configuration;
            BuildAppSettingsProvider();
        }
        private void BuildAppSettingsProvider()
        {
            _API = _configuration["API:Url"];
        }
    }
}

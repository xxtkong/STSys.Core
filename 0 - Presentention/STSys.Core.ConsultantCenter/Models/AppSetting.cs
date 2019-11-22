using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STSys.Core.ConsultantCenter.Models
{
    public class AppSetting
    {
        public string Api { get; set; }
        public string WxWebAppId { get; set; }
        public string WxWebAppSecret { get; set; }
        public string AliAppId { get; set; }
        public string AliAppPrivateKey { get; set; }
        public string AliAppPublicKey { get; set; }
    }
}

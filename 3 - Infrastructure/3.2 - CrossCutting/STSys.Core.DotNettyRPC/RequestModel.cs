using System.Collections.Generic;

namespace STSys.Core.DotNettyRPC
{
    class RequestModel
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public List<object> Paramters { get; set; }
    }
}

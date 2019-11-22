using System.Threading;

namespace STSys.Core.DotNettyRPC
{
    class ClientObj
    {
        public AutoResetEvent WaitHandler { get; set; } = new AutoResetEvent(false);
        public string ResponseString { get; set; }
    }
}

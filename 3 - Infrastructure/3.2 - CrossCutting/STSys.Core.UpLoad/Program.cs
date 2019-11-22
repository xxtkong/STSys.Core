using Microsoft.Extensions.Configuration;
using STSys.Core.DotNettyRPC;
using STSys.Core.File.Abstractions.Interfaces;
using STSys.Core.Files.Service;
using System;
using System.Text;

namespace STSys.Core.UpLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动上传服务");
            //注册编码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //注册配置文件
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            RPCServer server = new RPCServer(9999);
            server.RegisterService<IFileUpLoad, FileUpLoad>();
            server.Start();
            Console.ReadLine();
        }
    }
}

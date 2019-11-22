using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Console.Internal;
using System;
using System.IO;
using Topshelf;

namespace STSys.Core.Jobs
{
    class Program
    {
        public static ILoggerRepository _repository;

        static void Main(string[] args)
        {
            _repository = LogManager.CreateRepository("NETCoreRepository");
            BasicConfigurator.Configure(_repository);
            XmlConfigurator.ConfigureAndWatch(_repository, new FileInfo("config.xml"));
           
            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.RunAsLocalSystem();
                x.Service<ServiceRunner>();
                x.SetDescription(string.Format("{0} Ver:{1}", System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName"), System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                x.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceDisplayName"));
                x.SetServiceName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName"));
                x.EnablePauseAndContinue();
            });


            //ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            //BasicConfigurator.Configure(repository);
            //ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            //log.Info("输出日志");
            //log.Error("error");
            //log.Warn("warn");

        }
    }
}

using log4net;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using STSys.Core.Jobs.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;

namespace STSys.Core.Jobs
{
    public sealed class ServiceRunner : ServiceControl, ServiceSuspend
    {
        private readonly ILog _logger = LogManager.GetLogger(Program._repository.Name,typeof(ServiceRunner));
        private readonly IScheduler scheduler;

        private string ServiceName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName");
            }
        }

        public ServiceRunner()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.ListenerManager.AddJobListener(new SchedulerJobListener(), GroupMatcher<JobKey>.AnyGroup());
            scheduler.Start();
            new QuartzManager().JobScheduler(scheduler);
            //Console.WriteLine(string.Format("{0} 启动", ServiceName));

            _logger.Info(string.Format("{0} 启动", ServiceName));
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown(false);
            //Console.WriteLine(string.Format("{0} 停止", ServiceName));
            _logger.Info(string.Format("{0} 停止", ServiceName));
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            //Console.WriteLine(string.Format("{0} 继续", ServiceName));
            _logger.Info(string.Format("{0} 继续", ServiceName));
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            //Console.WriteLine(string.Format("{0} 暂停", ServiceName));
            _logger.Info(string.Format("{0} 暂停", ServiceName));
            return true;
        }

    }
}

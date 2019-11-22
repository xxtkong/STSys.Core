using log4net;
using Quartz;
using STSys.Core.Jobs.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Jobs.JobItems
{
    [DisallowConcurrentExecution]
    public class ManagerJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(Program._repository.Name, typeof(ManagerJob));
        public Task Execute(IJobExecutionContext context)
        {
            Version Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            _logger.InfoFormat("首途自动任务任务管理，当前版本：" + Ver.ToString());
            try
            {
                new QuartzManager().JobScheduler(context.Scheduler);
                _logger.InfoFormat("当前任务启动");
            }
            catch (Exception ex)
            {
                JobExecutionException e2 = new JobExecutionException(ex);
                e2.RefireImmediately = true;
            }
            finally
            {
                _logger.InfoFormat("当前任务结束");
            }
            return Task.CompletedTask;
        }
    }
}

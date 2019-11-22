using MediatR;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace STSys.Core.UsersApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController: ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        public NotificationController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpGet]
        [Route("Message")]
        public async Task<IEnumerable<string>> GetMessage(string controller)
        {
            var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
            return notificacoes.Select(s => { return s.Value; });
            
            //return new string[] { "张三", "里斯" };
        }
    }
}

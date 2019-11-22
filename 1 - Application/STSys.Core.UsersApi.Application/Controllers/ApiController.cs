using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Core.Bus;
using STSys.Core.Domain.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.UsersApi.Application.Controllers
{
    [Authorize]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }
    }
}

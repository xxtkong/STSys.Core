using STSys.Core.Domain.Core.Bus;
using STSys.Core.Domain.Core.Commands;
using STSys.Core.Domain.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Domain.CommandHandlers
{
    public class CommonHandler
    {
        private readonly IMediatorHandler _bus;
        public CommonHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }
        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.GetType().Name, error.ErrorMessage));
            }
        }
    }
}

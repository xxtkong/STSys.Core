using Common.Utility;
using MediatR;
using STSys.Core.Domain.CommandHandlers;
using STSys.Core.Domain.Core.Bus;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.Mediator;
using STSys.Core.Users.Abstractions.Commands;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STSys.Core.Users.CommandHandlers
{
    public class UsersCommandHandler : CommonHandler, IRequestHandler<UsersInsertCommand, bool>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediatorHandler _bus;
        public UsersCommandHandler(IUsersRepository usersRepository, IMediatorHandler bus) : base(bus)
        {
            this._usersRepository = usersRepository;
            this._bus = bus;
        }
        public Task<bool> Handle(UsersInsertCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                try
                {
                    using (var connection = _usersRepository.GetFirstConnection())
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                            connection.Open();
                        var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                        var model = _usersRepository.Find("select * from Users where mobile = @mobile", new { @mobile = request.Users.Mobile }, transaction);
                        if (model != null)
                        {
                            ///事件收集
                            _bus.RaiseEvent(new DomainNotification("", "该用户已存在！"));
                        }
                        else
                        {
                            var passwordSalt = Cryptographer.CreateSalt();
                            var password = Cryptographer.EncodePassword(request.Users.Password, 1, passwordSalt);
                            var result = _usersRepository.Insert(new UsersEntities(request.Users.Id, request.Users.UserName, password, request.Users.Name, request.Users.Email, DateTime.Now, request.Users.Mobile, (int)CommonState.正常, request.Users.PicUrl, passwordSalt), transaction);
                            transaction.Commit();
                            if (result != null)
                                return Task.FromResult(true);
                            return Task.FromResult(false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                //验证不通过
                NotifyValidationErrors(request);
            }
            return Task.FromResult(false);
        }
    }
}

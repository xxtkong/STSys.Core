using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Repository.Dapper.Common;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Repository.Users
{
    public class UsersRepository : DapperRepository<UsersEntities>, IUsersRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;
        public UsersRepository(STSysContext dbContext) : base(dbContext.DbConnections)
        {
            this._dbConnectionFactory = dbContext.DbConnections;
        }
    }
}

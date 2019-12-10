using Microsoft.EntityFrameworkCore;
using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Repository.EntityFramework.Common;
using STSys.Core.Domain.Extensions;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Data.Repository.Users
{
    public class ManagerRepository : Repository<ManagerEntities>, IManagerRepository
    {
        public ManagerRepository(STSysContext dbContext) : base(dbContext)
        {
        }

        public bool Edit(ManagerEntities entities, List<Expression<Func<ManagerEntities, dynamic>>> expressionList)
        {
            //_dbContext.Manager.Attach(entities);
            _dbContext.Entry<ManagerEntities>(entities).State = EntityState.Modified;
            //_dbContext.Entry<ManagerEntities>(entities).Property("Password").IsModified = false;
            //_dbContext.Entry<ManagerEntities>(entities).Property("CreateTime").IsModified = false;
            //_dbContext.Entry<ManagerEntities>(entities).Property(s=>s.Id).IsModified = false;
            foreach (var item in expressionList)
            {
                _dbContext.Entry<ManagerEntities>(entities).Property(item).IsModified = false;
            }
            return _dbContext.SaveChanges()>0;
        }

        public IQueryable<ManagerEntities> GetManagers(string account, string name, string mobile, string order, int? page, int? pageSize, out int pcount)
        {
           return GetAll()
                .CommonWhere(s => s.Account.Equals(account), !string.IsNullOrEmpty(account))
                .CommonWhere(s => s.Name.Contains(name), !string.IsNullOrEmpty(name))
                .CommonWhere(s => s.Mobile.Equals(mobile), !string.IsNullOrEmpty(mobile))
                .CommonOrder(Order.desc, order)
                .CommonPage(page.Value, pageSize.Value, out pcount);
        }
    }
}

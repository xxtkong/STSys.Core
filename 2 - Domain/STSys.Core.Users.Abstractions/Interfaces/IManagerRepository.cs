using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Users.Abstractions.Interfaces
{
    public interface IManagerRepository : IRepositoryEF<ManagerEntities>
    {
        IQueryable<ManagerEntities> GetManagers(string account, string name, string mobile, string order, int? page, int? pageSize, out int pcount);
        bool Edit(ManagerEntities entities, List<Expression<Func<ManagerEntities, dynamic>>> expressionList);
    }
}

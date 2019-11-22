using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
    }
}

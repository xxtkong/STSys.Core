using Microsoft.EntityFrameworkCore.Infrastructure;
using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Interfaces;
using STSys.Core.Data.Repository.EntityFramework.Common;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork, IRepositoryFactory
    {
        private readonly STSysContext _context;
        public UnitOfWork(STSysContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        private Dictionary<Type, object> repositories;
        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }
            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repositories[type];
        }
    }
}

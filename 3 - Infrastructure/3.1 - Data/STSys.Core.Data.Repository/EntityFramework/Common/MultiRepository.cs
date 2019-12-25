using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using STSys.Core.Data.Context;
using STSys.Core.Data.Repository.Dapper.Common;
using STSys.Core.Domain.Extensions;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Domain.Interfaces.Repository.Common;
using STSys.Core.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STSys.Core.Data.Repository.EntityFramework.Common
{
    public partial class MultiRepository<TEntity, K> : IMultiRepositoryEF<TEntity, K> where TEntity : class where K : DbContext
    {
        protected readonly K _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public MultiRepository(K dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.Count();
            }
            else
            {
                return _dbSet.Count(predicate);
            }
        }
        public virtual void Delete(object id)
        {
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }
        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);
        public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);
        public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
        public TEntity Find(Guid id) => _dbSet.Find(id);
        public async Task<TEntity> FindAsync(Guid id) => await _dbSet.FindAsync(id);
        public IQueryable<TEntity> GetAll() => _dbSet;

        public DbContext GetContext()
        {
            return _dbContext;
        }

        public IQueryable<TEntity> GetPage(Expression<Func<TEntity, bool>> where, int pageIndex, int pageSize, out int pcount)
        {
            return _dbSet.CommonPage(where, pageIndex, pageSize, out pcount);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, Order orderBy, string orderFile)
        {
            IQueryable<TEntity> db = null;
            if (where == null)
                db = _dbSet;
            else
            {
                db = _dbSet.Where(where);
            }
            var p = Expression.Parameter(typeof(TEntity), "s");
            var s = typeof(TEntity).GetProperty(orderFile);
            var m = Expression.MakeMemberAccess(p, s);
            var func = Expression.Lambda(m, p);
            switch (orderBy)
            {
                case Order.desc:
                    db = Queryable.OrderByDescending(db, (dynamic)func);
                    break;
                case Order.asc:
                    db = Queryable.OrderBy(db, (dynamic)func);
                    break;
                default:
                    break;
            }
            return db;
        }

        public void Insert(TEntity entity)
        {
            var entry = _dbSet.Add(entity);
        }
        public virtual void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);
        public virtual void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);
        public virtual Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);
        public void Update(TEntity entity) => _dbSet.Update(entity);
        public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);
        public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public bool Update(TEntity entity, List<Expression<Func<TEntity, dynamic>>> notModified)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            foreach (var item in notModified)
            {
                _dbContext.Entry<TEntity>(entity).Property(item).IsModified = false;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            _dbSet.RemoveRange(GetMany(where));
        }

        public IQueryable<TEntity> GetMany(string sql)
        {
            return _dbSet.FromSql(sql);
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    await action();
                    transaction.Commit();
                }
            });
        }
        public IQueryable<TEntity> GetMany(ISpecification<TEntity> spec)
        {
            // 获取包含所有基于表达式的包含的可查询项
            var queryableResultWithIncludes =
                spec.Includes.Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include));

            // 获取包含所有基于表达式的include的可查询项，修改可查询项以包含任何基于字符串的include语句
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            // 使用规范的条件表达式返回查询的结果
            return secondaryResult
                            .Where(spec.Criteria)
                            ;
        }
        public async Task<List<TEntity>> GetManyAsync(ISpecification<TEntity> spec)
        {
            //return await _dbContext.Set<TEntity>().Include("Items").ToListAsync();
            try
            {
                var queryableResultWithIncludes = spec.Includes
                       .Aggregate(_dbSet.AsQueryable(),
                           (current, include) => current.Include(include));
                var secondaryResult = spec.IncludeStrings
                    .Aggregate(queryableResultWithIncludes,
                        (current, include) => current.Include(include));
                return await secondaryResult
                                .Where(spec.Criteria)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

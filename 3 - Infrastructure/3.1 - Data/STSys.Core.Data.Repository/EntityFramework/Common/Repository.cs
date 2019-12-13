using Microsoft.EntityFrameworkCore;
using STSys.Core.Data.Context;
using STSys.Core.Data.Repository.Dapper.Common;
using STSys.Core.Domain.Extensions;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Domain.Interfaces.Specification;
using STSys.Core.Product.Abstractions.Entities;
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
    public partial class Repository<TEntity> : IRepositoryEF<TEntity> where TEntity : class
    {
        protected readonly STSysContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(STSysContext dbContext)
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

        public IQueryable<TEntity> GetMany(ISpecification<TEntity> spec)
        {

            //var p = _dbContext.Set<ProductEntities>().Include("Items").ToList();


            // 获取包含所有基于表达式的包含的可查询项
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<TEntity>().AsQueryable(),(current, include) => current.Include(include));

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
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }


        //protected readonly DbContext _dbContext;
        //protected readonly DbSet<TEntity> _dbSet;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        ///// </summary>
        ///// <param name="dbContext">The database context.</param>
        //public Repository(DbContext dbContext)
        //{
        //    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        //    _dbSet = _dbContext.Set<TEntity>();
        //}
        ///// <summary>
        ///// Gets all entities. This method is not recommended
        ///// </summary>
        ///// <returns>The <see cref="IQueryable{TEntity}"/>.</returns>
        //[Obsolete("This method is not recommended, please use GetPagedList or GetPagedListAsync methods")]
        //public IQueryable<TEntity> GetAll()
        //{
        //    return _dbSet;
        //}
        ///// <summary>
        ///// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        ///// </summary>
        ///// <param name="sql">The raw SQL.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        //public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <returns>The found entity or null.</returns>
        //public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <returns>A <see cref="Task{TEntity}" /> that represents the asynchronous insert operation.</returns>
        //public virtual Task<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task{TEntity}"/> that represents the asynchronous find operation. The task result contains the found entity or null.</returns>
        //public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

        ///// <summary>
        ///// Gets the count based on a predicate.
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <returns></returns>
        //public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return _dbSet.Count();
        //    }
        //    else
        //    {
        //        return _dbSet.Count(predicate);
        //    }
        //}

        ///// <summary>
        ///// Inserts a new entity synchronously.
        ///// </summary>
        ///// <param name="entity">The entity to insert.</param>
        //public virtual void Insert(TEntity entity)
        //{
        //    var entry = _dbSet.Add(entity);
        //}

        ///// <summary>
        ///// Inserts a range of entities synchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        //public virtual void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

        ///// <summary>
        ///// Inserts a range of entities synchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        //public virtual void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        ///// <summary>
        ///// Inserts a new entity asynchronously.
        ///// </summary>
        ///// <param name="entity">The entity to insert.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task"/> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return _dbSet.AddAsync(entity, cancellationToken);

        //    // Shadow properties?
        //    //var property = _dbContext.Entry(entity).Property("Created");
        //    //if (property != null) {
        //    //property.CurrentValue = DateTime.Now;
        //    //}
        //}

        ///// <summary>
        ///// Inserts a range of entities asynchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        ///// <returns>A <see cref="Task" /> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        ///// <summary>
        ///// Inserts a range of entities asynchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task"/> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddRangeAsync(entities, cancellationToken);

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public virtual void Update(TEntity entity)
        //{
        //    _dbSet.Update(entity);
        //}

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public virtual void UpdateAsync(TEntity entity)
        //{
        //    _dbSet.Update(entity);

        //}

        ///// <summary>
        ///// Updates the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        ///// <summary>
        ///// Updates the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        ///// <summary>
        ///// Deletes the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        ///// <summary>
        ///// Deletes the entity by the specified primary key.
        ///// </summary>
        ///// <param name="id">The primary key value.</param>
        //public virtual void Delete(object id)
        //{
        //    // using a stub entity to mark for deletion
        //    var typeInfo = typeof(TEntity).GetTypeInfo();
        //    var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
        //    var property = typeInfo.GetProperty(key?.Name);
        //    if (property != null)
        //    {
        //        var entity = Activator.CreateInstance<TEntity>();
        //        property.SetValue(entity, id);
        //        _dbContext.Entry(entity).State = EntityState.Deleted;
        //    }
        //    else
        //    {
        //        var entity = _dbSet.Find(id);
        //        if (entity != null)
        //        {
        //            Delete(entity);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Deletes the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        ///// <summary>
        ///// Deletes the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
    }
}

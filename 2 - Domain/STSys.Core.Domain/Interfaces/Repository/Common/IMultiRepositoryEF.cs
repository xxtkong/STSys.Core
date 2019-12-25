using Microsoft.EntityFrameworkCore;
using STSys.Core.Domain.Extensions;
using STSys.Core.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Domain.Interfaces.Repository.Common
{
    public interface IMultiRepositoryEF<TEntity, K> where TEntity : class where K : DbContext
    {
        IQueryable<TEntity> GetAll();
        TEntity Find(Guid id);
        Task<TEntity> FindAsync(Guid id);
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        void Insert(TEntity entity);
        void Insert(params TEntity[] entities);
        void Insert(IEnumerable<TEntity> entities);
        Task InsertAsync(params TEntity[] entities);
        void Update(TEntity entity);

        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="notModified">不需要修改字段</param>
        /// <returns></returns>
        bool Update(TEntity entity, List<Expression<Func<TEntity, dynamic>>> notModified);
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> where);
        DbContext GetContext();
        IQueryable<TEntity> GetPage(Expression<Func<TEntity, bool>> where, int pageIndex, int pageSize, out int pcount);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, Order orderBy, string orderFile);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetMany(string sql);
        /// <summary>
        /// 使用事务
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        Task ExecuteAsync(Func<Task> action);
        IQueryable<TEntity> GetMany(ISpecification<TEntity> spec);
        Task<List<TEntity>> GetManyAsync(ISpecification<TEntity> spec);


    }
}

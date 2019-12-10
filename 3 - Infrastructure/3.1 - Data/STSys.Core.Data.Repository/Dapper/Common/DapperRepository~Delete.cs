using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual void Delete(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await  _dbConnection.GetConnection("write").DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }


        public virtual void Delete(IEnumerable<TEntity> entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(IEnumerable<TEntity> entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await _dbConnection.GetConnection("write").DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }

        public virtual void Delete(IPredicate entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(IPredicate entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await  _dbConnection.GetConnection("write").DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }

        public virtual void Delete(object entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(object entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection.GetConnection("write").DeleteAsync(entity);
            else
                await transaction.Connection.DeleteAsync(entity, transaction);
        }
        /// <summary>
        /// 单表 根据条件删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public int Delete(Expression<Func<TEntity, bool>> where, IDbTransaction transaction = null)
        {
            var command = CommonHelper<TEntity>.GetPropertiesDelete(where);
            var pList = CommonHelper<TEntity>.GetOraParameters(command);
            if (transaction == null)
            {
               return  _dbConnection.GetConnection("write").Execute(command.Key, (object)pList); 
            }
            else
            {
                return _dbConnection.GetConnection("write").Execute(command.Key, (object)pList, transaction);
            }
        }
    }
}

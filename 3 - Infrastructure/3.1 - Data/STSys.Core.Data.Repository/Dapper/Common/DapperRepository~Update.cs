using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual void Update(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Update(entity);
            else
                transaction.Connection.Update(entity, transaction);
        }

        public virtual async Task UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection.GetConnection("write").UpdateAsync(entity);
            else
                await transaction.Connection.UpdateAsync(entity, transaction);
        }
        public virtual void Update(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Update(entities);
            else
                transaction.Connection.Update(entities, transaction);
        }
        public virtual async Task UpdateAsync(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection.GetConnection("write").UpdateAsync(entities);
            else
                await transaction.Connection.UpdateAsync(entities, transaction);
        }
        public virtual void Update(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection.GetConnection("write").Update(entities);
            else
                transaction.Connection.Update(entities, transaction);
        }
        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection.GetConnection("write").UpdateAsync(entities);
            else
                await transaction.Connection.UpdateAsync(entities, transaction);
        }

        /// <summary>
        /// 单表 更新需要更新的字段
        /// </summary>
        /// <param name="expression">更新字段 </param>
        /// <param name="where">条件</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public int Update(Expression<Func<TEntity>> expression, Expression<Func<TEntity, bool>> where, IDbTransaction transaction = null)
        {
            var command = CommonHelper< TEntity > .GetPropertiesUpdate(expression, where);
            var pList = CommonHelper<TEntity>.GetOraParameters(command); 
            if (transaction == null)
            {
                return _dbConnection.GetConnection("write").Execute(command.Key, (object)pList);
            }
            else
            {
                return transaction.Connection.Execute(command.Key, (object)pList, transaction);
            }
        }
     
    }

}
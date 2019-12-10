using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Dapper;
using static Dapper.SqlMapper;
using STSys.Core.Domain.Core.Common;
using System.Linq.Expressions;

namespace STSys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual int Count(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").Count<TEntity>(predicate);
            else
                return transaction.Connection.Count<TEntity>(predicate, transaction);
        }
        public virtual TEntity Find(int id, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").Get<TEntity>(id);
            else
                return transaction.Connection.Get<TEntity>(id, transaction);
        }
        public virtual TEntity Find(string sql, object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").QueryFirstOrDefault<TEntity>(sql, predicate);
            else
                return transaction.Connection.QueryFirstOrDefault<TEntity>(sql, predicate, transaction);
        }
        public virtual async Task<TEntity> FindAsync(string sql, object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").QueryFirstOrDefaultAsync<TEntity>(sql, predicate);
            else
                return await transaction.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, predicate, transaction);
        }

        public virtual TEntity Find(int id, CommittableTransaction transaction)
        {
            if (_dbConnection.GetConnection("read").State == ConnectionState.Closed)
                _dbConnection.GetConnection("read").Open();
            _dbConnection.GetConnection("read").EnlistTransaction(transaction);
            return _dbConnection.GetConnection("read").Get<TEntity>(id);
        }

        public virtual async Task<TEntity> FindAsync(int id, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").GetAsync<TEntity>(id);
            else
                return await transaction.Connection.GetAsync<TEntity>(id, transaction);
        }

        public virtual IEnumerable<TEntity> GetAll(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").GetList<TEntity>(predicate);
            else
                return transaction.Connection.GetList<TEntity>(predicate, null, transaction);

        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").GetListAsync<TEntity>(predicate);
            else
                return await transaction.Connection.GetListAsync<TEntity>(predicate, null, transaction);
        }
        public virtual IEnumerable<TEntity> GetPage(int page, int pageSize, IList<ISort> sorts, object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").GetPage<TEntity>(predicate, sorts, page, pageSize);
            else
                return transaction.Connection.GetPage<TEntity>(predicate, sorts, page, pageSize, transaction);
        }
        public virtual async Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize, IList<ISort> sorts, object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").GetPageAsync<TEntity>(predicate, sorts, page, pageSize);
            else
                return await transaction.Connection.GetPageAsync<TEntity>(predicate, sorts, page, pageSize, transaction);
        }

        public virtual IMultipleResultReader GetMultiple(GetMultiplePredicate predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").GetMultiple(predicate);
            else
                return transaction.Connection.GetMultiple(predicate, transaction);
        }

        public virtual IEnumerable<TEntity> GetFromSql(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").Query<TEntity>(sql, param);
            else
                return transaction.Connection.Query<TEntity>(sql, param, transaction);
        }
        public  IEnumerable<T> GetFromSql<T>(string sql, object param = null, IDbTransaction transaction = null) where T : class
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").Query<T>(sql, param);
            else
                return transaction.Connection.Query<T>(sql, param, transaction);
        }


        public virtual async Task<IEnumerable<TEntity>> GetFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").QueryAsync<TEntity>(sql, param);
            else
                return await transaction.Connection.QueryAsync<TEntity>(sql, param, transaction);
        }
        public virtual GridReader GetMultipleFromSql(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").QueryMultiple(sql, param);
            else
                return transaction.Connection.QueryMultiple(sql, param, transaction);
        }
        public virtual async Task<GridReader> GetMultipleFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").QueryMultipleAsync(sql, param);
            else
                return await transaction.Connection.QueryMultipleAsync(sql, param, transaction);
        }

        public IEnumerable<dynamic> GetDynamic(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection.GetConnection("read").Query<dynamic>(sql, param);
            else
                return transaction.Connection.Query<dynamic>(sql, param, transaction);
        }
        public async Task<IEnumerable<dynamic>> GetDynamicAsync(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection.GetConnection("read").QueryAsync<dynamic>(sql, param);
            else
                return await transaction.Connection.QueryAsync<dynamic>(sql, param, transaction);
        }
        public virtual PageDataView<TEntity> GetPage(PageCriteria criteria, object param = null, IDbTransaction transaction = null)
        {
            var p = new DynamicParameters();
            string proName = "ProcGetPageData";
            p.Add("TableName", criteria.TableName);
            p.Add("PrimaryKey", criteria.PrimaryKey);
            p.Add("Fields", criteria.Fields);
            p.Add("Condition", criteria.Condition);
            p.Add("CurrentPage", criteria.CurrentPage);
            p.Add("PageSize", criteria.PageSize);
            p.Add("Sort", criteria.Sort);
            p.Add("IsDesc", criteria.IsDesc);
            p.Add("RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var pageData = new PageDataView<TEntity>();
            if (transaction == null)
                pageData.Items = _dbConnection.GetConnection("read").Query<TEntity>(proName, p, commandType: CommandType.StoredProcedure).ToList();
            else
                pageData.Items = transaction.Connection.Query<TEntity>(proName, p, commandType: CommandType.StoredProcedure).ToList();
            pageData.TotalNum = p.Get<int>("RecordCount");
            pageData.TotalPageCount = Convert.ToInt32(Math.Ceiling(pageData.TotalNum * 1.0 / criteria.PageSize));
            pageData.CurrentPage = criteria.CurrentPage > pageData.TotalPageCount ? pageData.TotalPageCount : criteria.CurrentPage;
            return pageData;
        }

        /// <summary>
        /// 单表 查询一条数据
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public TEntity First(Expression<Func<TEntity, bool>> where, IDbTransaction transaction = null)
        {
            var command = CommonHelper<TEntity>.GetPropertiesFirst(where);
            var pList = CommonHelper<TEntity>.GetOraParameters(command);
            if (transaction == null)
            {
                var list = _dbConnection.GetConnection("read").Query<TEntity>(command.Key, (object)pList).ToList();
                return (list != null && list.Count > 0) ? list.FirstOrDefault() : CommonHelper<TEntity>.Copy(null);
            }
            else
            {
                var list = _dbConnection.GetConnection("read").Query<TEntity>(command.Key, (object)pList, transaction).ToList();
                return (list != null && list.Count > 0) ? list.FirstOrDefault() : CommonHelper<TEntity>.Copy(null);
            }
        }

        public IEnumerable<TEntity> GetMany(string sql, object parameters, IDbTransaction transaction = null)
        {

            if (transaction == null)
            {
                return  _dbConnection.GetConnection("read").Query<TEntity>(sql, parameters).ToList(); 
            }
            else
            {
                return  _dbConnection.GetConnection("read").Query<TEntity>(sql, parameters, transaction).ToList();
            } 
        }


        public IEnumerable<T> GetMany<T>(string sql, object parameters, IDbTransaction transaction = null)where T:class
        {

            if (transaction == null)
            {
                return _dbConnection.GetConnection("read").Query<T>(sql, parameters).ToList();
            }
            else
            {
                return _dbConnection.GetConnection("read").Query<T>(sql, parameters, transaction).ToList();
            }
        }
    }
}


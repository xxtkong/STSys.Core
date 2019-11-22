using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Data.Repository.EntityFramework.Common
{
    public static class PageHelperExtensions
    {
        public static IQueryable<TEntity> CommonPage<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> where,int pageIndex, int pageSize, out int pcount) where TEntity : class
        {
            var source = queryable.Where(where);
            pcount = source.Count();
            int pageCount;
            if (pcount % pageSize > 0)
                pageCount = pcount / pageSize + 1;
            else
                pageCount = pcount / pageSize;
            return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}

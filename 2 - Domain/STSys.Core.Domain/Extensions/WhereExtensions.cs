using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Domain.Extensions
{
    public static class WhereExtensions
    {
        public static IQueryable<T> CommonWhere<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> where, bool condition) where T : class
        {
            if (condition)
                return queryable.Where(where);
            return queryable;
        }
    }
}

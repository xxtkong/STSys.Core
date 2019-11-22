using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static IQueryable<T> CommonOrder<T>(this IQueryable<T> queryable, Order orderBy, string orderFile) where T:class
        {
            try
            {
                var p = Expression.Parameter(typeof(T), "s");
                var s = typeof(T).GetProperty(orderFile);
                var m = Expression.MakeMemberAccess(p, s);
                var func = Expression.Lambda(m, p);
                switch (orderBy)
                {
                    case Order.desc:
                        queryable = Queryable.OrderByDescending(queryable, (dynamic)func);
                        break;
                    case Order.asc:
                        queryable = Queryable.OrderBy(queryable, (dynamic)func);
                        break;
                    default:
                        break;
                }
                return queryable;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

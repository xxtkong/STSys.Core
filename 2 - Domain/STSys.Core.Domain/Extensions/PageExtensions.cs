using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Domain.Extensions
{
    public static class PageExtensions
    {
        public static IQueryable<T> CommonPage<T>(this IQueryable<T> queryable, int pageIndex, int pageSize, out int pcount) where T : class
        {
            pcount = queryable.Count();
            int pageCount;
            if (pcount % pageSize > 0)
                pageCount = pcount / pageSize + 1;
            else
                pageCount = pcount / pageSize;
            return queryable.Skip((pageIndex -1) * pageSize).Take(pageSize);
        }
    }
}

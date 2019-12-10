using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Repository.EntityFramework.Common;
using STSys.Core.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Data.Repository.Admin
{
    public class ColumnRepository : Repository<ColumnEntity>, IColumnRepository
    {
        public ColumnRepository(STSysContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ColumnEntity> GetPage(string name, string sort, out int pcount, bool? sortDesc = true, int? page = 1, int? pageSize = 10)
        {
            return GetAll()
                .CommonWhere(s => s.ColumnName.Equals(name), !string.IsNullOrEmpty(name))
                .CommonOrder(Order.desc, sort)
                .CommonPage(page.Value, pageSize.Value, out pcount);
        }
    }
}

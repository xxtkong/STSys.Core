using STSys.Core.Admin.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Interfaces
{
    public interface IColumnRepository
    {
        IQueryable<ColumnEntity> GetPage(string name, string sort, out int pcount, bool? sortDesc = true, int? page = 1, int? pageSize = 10);
    }
}

using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class ColumnEntity : Entity
    {
        public string ColumnName { get; set; }
        public string ColumnEName { get; set; }
        public string Intro { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Url { get; set; }
        public Nullable<int> ColumnType { get; set; }
        public string Tab { get; set; }
        public int? DataSource { get; set; }
        public int? Source { get; set; }
    }
}

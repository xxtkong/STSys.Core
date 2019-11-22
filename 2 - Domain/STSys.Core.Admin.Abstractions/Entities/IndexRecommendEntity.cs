using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Abstractions.Entities
{
    public class IndexRecommendEntity : Entity
    {
        public short Type { get; set; }
        public Nullable<int> ProId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<int> ColumnId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Img { get; set; }
        public decimal? Price { get; set; }
        public string Url { get; set; }
        public Guid? TabId { get; set; }
        public int? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class SelectDataViewModel
    {
        public Guid? Id { get; set; }
        public int? Sort { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Img { get; set; }
        public decimal? Price { get; set; }
        public string Url { get; set; }
        public Guid TabId { get; set; }
        public int? Status { get; set; }

    }
}

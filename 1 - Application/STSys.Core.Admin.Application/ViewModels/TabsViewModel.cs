using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class TabsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Img { get; set; }
        public string Intro { get; set; }
        public string Url { get; set; }
        public int? Status { get; set; }
    }
}

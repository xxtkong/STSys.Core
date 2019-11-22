using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class TreeViewModel
    {

        public Guid id { get; set; }
        public Guid? Pid { get; set; }
        public string name { get; set; }
        public bool isParent { get; set; }
        public bool open { get; set; }
        public IList<TreeViewModel> children { get; set; }
    }
}

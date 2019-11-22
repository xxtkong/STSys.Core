using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class ModuleViewModel
    {
        [Required(ErrorMessage = "模块名称必填")]
        [Display(Name = "模块名称")]
        [MaxLength(50, ErrorMessage = "最大长度为50个字符")]
        public string Name { get; set; }

        public string URL { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public Guid? Pid { get; set; }
        public short IsMenu { get; set; }
        public string PName { get; set; }
        public int Level { get; set; }
    }
}

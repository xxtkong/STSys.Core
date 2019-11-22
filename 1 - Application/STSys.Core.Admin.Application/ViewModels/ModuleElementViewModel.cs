using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class ModuleElementViewModel
    {
        [Required(ErrorMessage = "DomId必填")]
        [Display(Name = "DomId")]
        [MaxLength(50, ErrorMessage = "最大长度为50个字符")]
        public string DomId { get; set; }
        [Required(ErrorMessage = "按钮名称必填")]
        [Display(Name = "按钮名称")]
        [MaxLength(50, ErrorMessage = "最大长度为50个字符")]
        public string Name { get; set; }
        public string Script { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public Guid ModuleId { get; set; }
        public string URL { get; set; }
    }
}

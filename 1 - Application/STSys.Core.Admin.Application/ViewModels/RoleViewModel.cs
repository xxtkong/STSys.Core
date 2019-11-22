using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "角色名称必填")]
        [Display(Name = "角色名称")]
        [MaxLength(50, ErrorMessage = "最大长度为50个字符")]
        public string Name { get; set; }
    }
}

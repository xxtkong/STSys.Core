using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Application.Extensions;
using STSys.Core.Admin.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    //[ModelBinder(BinderType = typeof(ManagerBinder))]
    public class ManagerViewModel
    {
        [Required(ErrorMessage = "账户必填")]
        [Display(Name = "账户")]
        [MaxLength(50, ErrorMessage = "最大长度为50个字符")]
        public string Account { get; set; }
      
        [Required(ErrorMessage = "姓名必填")]
        [Display(Name = "姓名")]
        [MaxLength(20,ErrorMessage = "最大长度为20个字符")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "联系电话必填")]
        [Display(Name = "联系电话")]
        [MaxLength(11,ErrorMessage = "最大长度为11个字符")]
        [MobileValidation(ErrorMessage ="请输入联系电话")]
        public string Mobile { get; set; }
        [MaxLength(20, ErrorMessage = "最大长度为20个字符")]
        public string QQ { get; set; }
        [EmailAddress]
        [MaxLength(200, ErrorMessage = "最大长度为200个字符")]
        public string Email { get; set; }
        [MaxLength(200, ErrorMessage = "最大长度为200个字符")]
        public string Address { get; set; }
        [MaxLength(500, ErrorMessage = "最大长度为500个字符")]
        public string PicUrl { get; set; }
    }

    public class ResetPwd
    {
        [Required(ErrorMessage = "密码必填")]
        public string Pwd { get; set; }
        public Guid Id { get; set; }
    }
}

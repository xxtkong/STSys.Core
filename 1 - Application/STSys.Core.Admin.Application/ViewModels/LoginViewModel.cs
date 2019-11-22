using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入用户名")]
        [Display(Name = "用户名")]
        [BindProperty]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码必填")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        [BindProperty]
        public string Pwd { get; set; }

    }
}

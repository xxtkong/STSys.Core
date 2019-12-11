using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STSys.Core.Quarzt.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名必填")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码必填")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]

        public string Pwd { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}
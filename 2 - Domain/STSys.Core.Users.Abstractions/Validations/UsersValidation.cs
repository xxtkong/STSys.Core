using FluentValidation;
using STSys.Core.Domain.Interfaces.Validation;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Validations
{
    public class UsersValidation : IValidation<UsersEntities>
    {
        public UsersValidation()
        {
            //首先验证电话号码必填
            RuleFor(o => o.Mobile).NotNull().WithMessage("联系电话必填").Matches(@"^1\d{10}$").WithMessage("请输入正常的电话号码");
            RuleFor(s => s.UserName).NotEmpty().WithMessage("用户名必填").MaximumLength(50).WithMessage("输入过长");
            RuleFor(s => s.Password).NotEmpty().WithMessage("密码必填");
            //邮件验证
            RuleFor(s => s.Email).EmailAddress().WithMessage("请输入正确的邮件地址");

        }
    }
}

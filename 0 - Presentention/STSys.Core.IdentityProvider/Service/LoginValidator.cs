using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.IdentityProvider.Common;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STSys.Core.IdentityProvider.Service
{
    public class LoginValidator : IResourceOwnerPasswordValidator
    {
        private readonly IRepository<UsersEntities> _repository;
        public LoginValidator(IRepository<UsersEntities> repository)
        {
            this._repository = repository;
        }
        /// <summary>
        /// 登录用户校验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            //context.Result = new GrantValidationResult(
            //        subject: "18623505212",
            //        authenticationMethod: "custom",
            //        claims: new Claim[]
            //        {
            //            new Claim(JwtClaimTypes.Name,"18623505212"),
            //            new Claim(JwtClaimTypes.GivenName,"18623505212"),
            //            new Claim(JwtClaimTypes.FamilyName, "18623505212"),
            //            new Claim(JwtClaimTypes.Role,"company")
            //        });
            var companyRoleCount = context.Request.ClientClaims.Count(s => s.Value.Contains("company"));
            if (companyRoleCount > 0)
            {
                var user = _repository.Find("select * from Users where Mobile = @mobile and Password =@password and Status = 0", new { mobile = context.UserName, @password = context.Password });
                if (user != null)
                {
                    context.Result = new GrantValidationResult(
                          subject: user.Id.ToString(),
                          authenticationMethod: "custom",
                          claims: GetUserClaims(user));
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户不存在");
                }
            }
            else
            {
                var consultantRoleCount = context.Request.ClientClaims.Count(s => s.Value.Contains("consultant"));
                if (consultantRoleCount > 0)
                {
                    //查询服务顾问

                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户不存在");
            }

        }

       

        /// <summary>
        /// 可以根据需要设置相应的Claim
        /// </summary>
        /// <returns></returns>
        private Claim[] GetUserClaims(UsersEntities model)
        {
            return new Claim[]
            {
                new Claim("UserId", model.Id.ToString()),
                new Claim(JwtClaimTypes.Name,model.UserName),
                new Claim(JwtClaimTypes.GivenName,model.UserName),
                new Claim(JwtClaimTypes.FamilyName, model.UserName),
                new Claim(JwtClaimTypes.PhoneNumber, model.Mobile),
                new Claim(JwtClaimTypes.Role,"Company")//用户角色
            };
        }
    }
}

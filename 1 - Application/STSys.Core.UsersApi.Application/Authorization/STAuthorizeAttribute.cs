using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.UsersApi.Application.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class STAuthorizeAttribute : AuthorizeAttribute
    {
        public string Permission { get; set; }
        public STAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }

    }
}

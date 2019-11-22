using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Authorization
{
    public class AuthorizeAdminAttribute : TypeFilterAttribute
    {
        public readonly bool _authorizeFilter;
        public AuthorizeAdminAttribute(bool authorize = true) : base(typeof(AuthorizeAdminFilter))
        {
            this._authorizeFilter = authorize;
            this.Arguments = new object[] { authorize };
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace STSys.Core.Admin.Application.Extensions
{
    public class AdminContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminContext(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public Guid current
        {
            get
            {
                return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Sid).Value);
            }
        }
    }
}

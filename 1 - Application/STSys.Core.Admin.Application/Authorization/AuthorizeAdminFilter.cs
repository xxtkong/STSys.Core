using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Cache;
using STSys.Core.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace STSys.Core.Admin.Application.Authorization
{

    public class AuthorizeAdminFilter : IAuthorizationFilter
    {
        private readonly bool _authorizeFilter;
        public AuthorizeAdminFilter(bool authorizeFilter)
        {
            this._authorizeFilter = authorizeFilter;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));
            var actionFilter = filterContext.ActionDescriptor.FilterDescriptors
                .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                .Select(filterDescriptor => filterDescriptor.Filter).OfType<AuthorizeAdminAttribute>().FirstOrDefault();
            if (!actionFilter?._authorizeFilter??false)
                return;
            if (filterContext.Filters.Any(filter => filter is AuthorizeAdminFilter))
            {
                var uid = filterContext.HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Sid).Value;
                //获取当前请求的URL 
                var loginRoleData = CommonManager.CacheObj.GetCache<IList<LoginRoleDto>>("nav" + uid.ToString());
                if (loginRoleData == null)
                    filterContext.Result = new RedirectResult("/Login/Index");
                else
                {
                    var url = filterContext.HttpContext.Request.Path.Value.ToLower();
                    if (url.Split('/').Length == 2)
                        url = url + "/index";
                    if (string.IsNullOrEmpty(url.Split('/')[2]))
                        url = url + "index";
                    if (url.Split('/').Length > 3)
                        url = url.Split('/')[0] + "/" + url.Split('/')[1] + "/" + url.Split('/')[2];
                    var first = loginRoleData.YDBSFirst(s => (s.moduleElements.URL?.ToLower()??"").Equals(url));
                    if(first == null)
                        filterContext.Result = new RedirectResult("/Login/Index");
                }
            }
        }
    }
}

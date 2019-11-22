using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Cache;
using STSys.Core.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace STSys.Core.Admin.Application.HtmlExt
{
    public static class ButtonHelper
    {
        public static HtmlString Button(this IHtmlHelper html, string id)
        {
            return Button(html, id, "javascript:void(0)","","700","700","");
        }
        public static HtmlString Button(this IHtmlHelper html, string id, string href)
        {
            return Button(html, id, href, "", "700", "700", "");
        }
        public static HtmlString Button(this IHtmlHelper html, string id, string href, string js)
        {
            return Button(html, id, href, js, "700", "700", "");
        }
        public static HtmlString Button(this IHtmlHelper html, string id,string js, string dataWidth, string dataHeight)
        {
            return Button(html, id, js: js, dataWidth: dataWidth, dataHeight: dataHeight, property: "");
        }
        public static HtmlString Button(this IHtmlHelper html, string id, string href = "javascript:void(0)",string js ="",string dataWidth = "700", string dataHeight= "700",string property = "")
        {
            var url = html.ViewContext.HttpContext.Request.Path.Value.ToLower();
            var requestType = html.ViewContext.HttpContext.Request.Headers["requestType"];
            if (url.Split('/').Length == 2)
                url = url + "/index";
            if (string.IsNullOrEmpty(url.Split('/')[2]))
                url = url + "index";
            if (url.Split('/').Length > 3)
                url = url.Split('/')[0] + "/" + url.Split('/')[1] + "/" + url.Split('/')[2];
            var httpContextAccessor = html.ViewContext.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var uid = Guid.Parse(httpContextAccessor.HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Sid).Value);
            var loginRoleData = CommonManager.CacheObj.GetCache<IList<LoginRoleDto>>("nav" + uid.ToString());
            if (loginRoleData == null)
                return new HtmlString("");
            else
            {
                var first = loginRoleData.YDBSFirst(s => s.modules.URL.ToLower().Equals(url));
                if (first != null)
                {
                    var dom = loginRoleData.YDBSFirst(s => s.moduleElements.DomId.ToLower().Equals(id.ToLower()) && s.moduleElements.ModuleId.Equals(first.modules.Id));
                    if (dom != null)
                    {
                        var element = dom.moduleElements;
                        StringBuilder sb = new StringBuilder();
                        var defaultHref = element.URL ?? "javascript:void(0)";
                        if (!string.IsNullOrEmpty(href) && (href.Trim() != "javascript:void(0)" || href.Trim() != "javascript:;"))
                            defaultHref = href;
                        var defaultJs = element.Script;
                        if (!string.IsNullOrEmpty(js))
                            defaultJs = js;
                        sb.Append($"<a id={id} class=\"{element.Class?? "btn btn-info"}\" href=\"{defaultHref}\" {defaultJs} title=\"{element.Name}\"  data-width=\"{dataWidth}\" data-height=\"{dataHeight}\" {property}><i class=\"fa {element.Icon}\"></i> {element.Name}</a>");
                        return new HtmlString(sb.ToString());
                    }
                }
            }
            return new HtmlString("");
        }
    }
}

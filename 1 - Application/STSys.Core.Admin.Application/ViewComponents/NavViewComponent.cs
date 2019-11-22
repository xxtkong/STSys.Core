using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.Admin.Application.Extensions;
using STSys.Core.Cache;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace STSys.Core.Admin.Application.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private readonly IRepositoryEF<RelevanceRoleEntity> _relevanceRole;
        private readonly IRepositoryEF<ModuleEntity> _module;
        private readonly IRoleRepository _roleRepository;
        public NavViewComponent(IRepositoryEF<RelevanceRoleEntity> relevanceRole, IRepositoryEF<ModuleEntity> module, IRoleRepository roleRepository)
        {
            this._relevanceRole = relevanceRole;
            this._module = module;
            this._roleRepository = roleRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loginUserId = Guid.Parse(HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Sid).Value);
            var tuple = GetCurrentUser(loginUserId);
            var moduls = _module.GetAll();
            StringBuilder sb = new StringBuilder("<ul class=\"nav\" id=\"side-menu\">" +
                "<li class=\"nav-header\"><div class=\"dropdown profile-element\"><a data-toggle=\"dropdown\" class=\"dropdown-toggle\" href =\"/main/index\" ><span class=\"clear\"><span class=\"block m-t-xs\" style=\"font-size:20px;\"><i class=\"fa fa-area-chart\"></i><strong class=\"font-bold\">后台管理系统</strong></span></span></a></div><div class=\"logo-element\">BBW</div></li>");
            sb.Append("<li class=\"hidden-folded padder m-t m-b-sm text-muted text-xs\"><span class=\"ng-scope\">分类</span></li>");
            sb.Append("<li><a class=\"J_menuItem\" href=\"/main/index\"><i class=\"fa fa-home\"></i><span class=\"nav-label\">主页</span></a></li>");
            foreach (var item in tuple.GroupBy(s=>s.modules.Pid))
            {
                var p = moduls.First(s => s.Id.Equals(item.FirstOrDefault().modules.Pid));
                sb.Append("<li><a href=\"#\"><i class=\"fa fa "+p.Icon+"\"></i><span class=\"nav-label\">"+p.Name+"</span><span class=\"fa arrow\"></span></a>" +
                    "<ul class=\"nav nav-second-level collapse\">");
                var soruce = item.OrderBy(s => s.modules.Sort);
                foreach (var item2 in soruce)
                {
                    if (!sb.ToString().Contains(item2.modules.Id.ToString()))
                        sb.Append("<li id=\"" + item2.modules.Id + "\"><a class=\"J_menuItem\" href=\"" + item2.modules.URL + "\">" + item2.modules.Name + "</a></li>");
                }
                sb.Append("</ul></li>");
            }
            sb.Append("</ul>");
            ViewBag.nav = sb.ToString();
            return View();
        }

        private IList<LoginRoleDto> GetCurrentUser(Guid uid)
        {
            var cacheProvider = new CacheContext();
            IList<LoginRoleDto> mt = null;
            if (cacheProvider.GetCache<IList<LoginRoleDto>>("nav" + uid.ToString()) == null)
            {
                var tuple = _roleRepository.GetCurrentUser(uid).ToList();
                CommonManager.CacheObj.SetCache("nav" + uid.ToString(), tuple);
                return tuple;
            }
            else
            {
                mt = CommonManager.CacheObj.GetCache<IList<LoginRoleDto>>("nav" + uid.ToString());
            }
            return mt;
        }
    }
}

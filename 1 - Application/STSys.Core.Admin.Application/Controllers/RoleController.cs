using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Data.Context.Interfaces;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Extensions;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.Admin.Application.Controllers
{
    public class RoleController : BaseContorller
    {
        private readonly IRepositoryEF<RoleEntity> _repositoryEF;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRepositoryEF<RoleEntity> repositoryEF, IMapper mapper, IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this._repositoryEF = repositoryEF;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
        }
        public IActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            var model = SearchData("", pageIndex.Value, pageSize.Value);
            return View(model);
        }
        public ActionResult Search(string name, int? pageIndex = 1, int? pageSize = 10)
        {
            var model = SearchData(name, pageIndex.Value, pageSize.Value);
            return PartialView("List", model);
        }
        private IQueryable<RoleEntity> SearchData(string name,int? pageIndex = 1, int? pageSize = 10)
        {
            Expression<Func<RoleEntity, bool>> filter = s => true;
            if (!string.IsNullOrEmpty(name))
                filter = filter.And(s => s.Name.Equals(name));
            int pcount;
            var result = _repositoryEF.GetPage(filter, pageIndex.Value, pageSize.Value, out pcount);
            ViewBag.PageSize = pageSize.Value;
            ViewBag.TotalCount = pcount;
            return result;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<RoleEntity>(model);
                entity.Status = (int)CommonState.正常;
                entity.CreateTime = DateTime.Now;
                _repositoryEF.Insert(entity);
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            return Json(new { d = false });
        }

        public IActionResult Edit(Guid id)
        {
            var result = _repositoryEF.Find(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoleEntity entities)
        {
            if (ModelState.IsValid)
            {
                _repositoryEF.Update(entities, new List<Expression<Func<RoleEntity, dynamic>>>()
                    { s=>s.Status,s=>s.CreateTime}
                );
                return RedirectToAction("Index");
            }
            return View(entities);
        }

        public virtual IActionResult Delete(Guid id)
        {
            _repositoryEF.Delete(id);
            _unitOfWork.Commit();
            return Json(new { d = true });
        }

        public IActionResult Assign(Guid id)
        {
            ViewBag.id = id;
            return View();
        }

        public string LoadElement(Guid roleId,Guid moduleId)
        {
            var result = _roleRepository.LoadElement(roleId, moduleId);
            var html = BuilderModules(result);
            return html;
        }

        private string BuilderModules(Tuple<IQueryable<ModuleElementEntity>, IQueryable<RelevanceElementEntity>> tuple)
        {
            StringBuilder sb = new StringBuilder();
            var all = tuple.Item1;
            var relevance = tuple.Item2;
            sb.Append("<div class=\"row\">");
            foreach (var item in all)
            {
                var isC = relevance.Count(s => s.ElementId.Equals(item.Id)) > 0 ? "checked" : "";
                sb.Append($"<div class=\"col-xs-3\"><div class=\"onoffswitch\"><input name = \"switch\" class=\"onoffswitch-checkbox\" type=\"checkbox\" {isC}  onclick=\"isassign(this)\" value=\"{item.Id}\" id=\"chk{item.Id}\" />");
                sb.Append($"<label class=\"onoffswitch-label\" for=\"chk{item.Id}\"><span class=\"onoffswitch-inner\"></span><span class=\"onoffswitch-switch\"></span></label>");
                sb.Append($"</div><span>{item.Name}</span></div>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }
        public IActionResult SaveAssign(Guid roleId, Guid elementId, Guid moduleId, Guid managerId, bool ischecked)
        {
            _roleRepository.SaveAssign(roleId, elementId, moduleId, GetLoginUserId, ischecked);
            return View();
        }
    }
}

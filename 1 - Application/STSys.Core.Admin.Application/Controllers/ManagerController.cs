using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Application.Extensions;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Data.Context.Interfaces;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Interfaces;
using System.Linq;
using STSys.Core.Domain.Core.Common;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.Admin.Application.Authorization;

namespace STSys.Core.Admin.Application.Controllers
{
    [AuthorizeAdmin()]
    public class ManagerController:BaseContorller
    {
        private readonly IRepositoryEF<ManagerEntities> _repositoryEF;
        private readonly IManagerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public ManagerController(IRepositoryEF<ManagerEntities> repositoryEF, IManagerRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository)
        {
            this._repositoryEF = repositoryEF;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._roleRepository = roleRepository;
        }

        [AuthorizeAdmin(false)] //不需要权限控制 
        public IActionResult Index()
        {
            var model = Search("", "", "");
            return View(model);
        }
        
        public IQueryable<ManagerEntities> Search(string account,string name,string mobile, int size = 1, int page =1, string sort = "Account", string sortBy = "desc")
        {
            int pcount;
            var result = _repository.GetManagers(account, name, mobile, sort, page, size, out pcount);
            ViewBag.PageSize = size;
            ViewBag.TotalCount = pcount;
            return result;
        }
        [AuthorizeAdmin(false)]
        public IActionResult List(string account, string name, string mobile, int pageIndex = 1)
        {
            var model = Search(account, name, mobile,page:pageIndex);
            return PartialView("List", model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ManagerViewModel entities)
        {
            if (ModelState.IsValid)
            {
                var isTrue = _repositoryEF.Count(s => s.Account.Equals(entities.Account) || s.Mobile.Equals(entities.Mobile)) > 0;
                if (isTrue)
                {
                    ModelState.AddModelError("Account", "该账户或联系电话已存在");
                    return View(entities);
                }
                var entity = _mapper.Map<ManagerEntities>(entities);
                entity.Status = (int)CommonState.正常;
                entity.CreateTime = DateTime.Now;
                entity.Encrypt = Cryptographer.CreateSalt();
                entity.Password = Cryptographer.EncodePassword("123qwe", 1, entity.Encrypt);
                await _repositoryEF.InsertAsync(entity);
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            return Json(new { d = false });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _repository.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ManagerEntities entities)
        {
            if (ModelState.IsValid)
            {
                var isTrue = _repositoryEF.Count(s => s.Id != entities.Id && (s.Account.Equals(entities.Account) || s.Mobile.Equals(entities.Mobile))) > 0;
                if (isTrue)
                {
                    ModelState.AddModelError("Account", "该账户或联系电话已存在");
                    return View(entities);
                }
                _repositoryEF.Update(entities, new List<System.Linq.Expressions.Expression<Func<ManagerEntities, dynamic>>>()
                    { s => s.Password, s => s.Status,s=>s.CreateTime,s=>s.Encrypt }
                );
                return Json(new { d = true });
            }
            return Json(new { d = false });
        }

        public virtual IActionResult Delete(Guid id)
        {
            _repositoryEF.Delete(id);
            _unitOfWork.Commit();
            return Json(new { d = true });
        }

        public IActionResult Reset(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reset(ResetPwd reset)
        {
            if (ModelState.IsValid)
            {
                var model = _repositoryEF.Find(reset.Id);
                if (model == null)
                    return Json(new { Data = false });
                else
                {
                    model.Encrypt = Cryptographer.CreateSalt();
                    model.Password = Cryptographer.EncodePassword(reset.Pwd, 1, model.Encrypt);
                    _repositoryEF.Update(model);
                    _unitOfWork.Commit();
                    return Json(new { Data = true });
                }
            }
            return Json(new { Data = false });
        }

        public IActionResult Role(Guid id)
        {
            ViewBag.id = id;
            var result = BuilderModules(_roleRepository.GetMany(id));
            ViewBag.result = result;
            return View();
        }
        private string BuilderModules(Tuple<IQueryable<RoleEntity>, IQueryable<RelevanceRoleEntity>> tuple)
        {
            StringBuilder sb = new StringBuilder();
            var all = tuple.Item1;
            var relevance = tuple.Item2;
            sb.Append("<div class=\"row\">");
            foreach (var item in all)
            {
                var isC = relevance.Count(s => s.RoleId == item.Id) > 0 ? "checked" : "";
                sb.Append($"<div class=\"col-xs-3\"><div class=\"onoffswitch\"><input name = \"switch\" class=\"onoffswitch-checkbox\" type=\"checkbox\" {isC}  onclick=\"isassign(this)\" value=\"{item.Id}\" id=\"chk{item.Id}\" />");
                sb.Append($"<label class=\"onoffswitch-label\" for=\"chk{item.Id}\"><span class=\"onoffswitch-inner\"></span><span class=\"onoffswitch-switch\"></span></label>");
                sb.Append($"</div><span>{item.Name}</span></div>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        [HttpPost]
        public ActionResult Assign(Guid managerId, Guid roleId, bool ischecked)
        {
            _roleRepository.Assign(managerId, roleId, GetLoginUserId,ischecked);
            return View();
        }
    }
}

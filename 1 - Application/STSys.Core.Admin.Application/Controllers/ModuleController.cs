using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Abstractions.Entities;
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
    public class ModuleController : BaseContorller
    {
        private readonly IRepositoryEF<ModuleEntity> _repositoryEF;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryEF<ModuleElementEntity> _moduleElementRepository;
        public ModuleController(IRepositoryEF<ModuleEntity> repositoryEF, IMapper mapper, IUnitOfWork unitOfWork, IRepositoryEF<ModuleElementEntity> moduleElementRepository)
        {
            this._repositoryEF = repositoryEF;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._moduleElementRepository = moduleElementRepository;
        }
        public IActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            var model = Search("", null);
            return View(model);
        }
        public IActionResult List(string name, Guid? pid, int? pageIndex = 1, int? pageSize = 10)
        {
            var model = Search(name, pid, pageIndex, pageSize);
            return PartialView("List", model);
        }
        public IQueryable<ModuleEntity> Search(string name, Guid? pid, int? pageIndex = 1, int? pageSize = 10)
        {
            try
            {
                //构建表达式
                Expression<Func<ModuleEntity, bool>> filter = s => true;
                if (!string.IsNullOrEmpty(name))
                    filter = filter.And(s => s.Name.Equals(name));
                if (pid != null)
                    filter = filter.And(s => s.Pid == pid);
                int pcount;
                var result = _repositoryEF.GetPage(filter, pageIndex.Value, pageSize.Value, out pcount);
                ViewBag.PageSize = pageSize.Value;
                ViewBag.TotalCount = pcount;
                return result;
                
                ////s => s.Name.Equals(name) && s.Pid == pid
                //ParameterExpression parameter = Expression.Parameter(typeof(ModuleEntity), "s");
                //BinaryExpression leftBinary = null, rightBinary = null;
                //if (!string.IsNullOrEmpty(name))
                //{
                //    var pName = typeof(ModuleEntity).GetProperty("Name");
                //    MemberExpression property = Expression.MakeMemberAccess(parameter, pName);
                //    ConstantExpression constant = Expression.Constant(name);
                //    leftBinary = Expression.MakeBinary(ExpressionType.Equal, property, constant);
                //}
                //if (pid != null)
                //{
                //    var pPid = typeof(ModuleEntity).GetProperty("Pid");
                //    MemberExpression property = Expression.MakeMemberAccess(parameter, pPid);
                //    ConstantExpression constant = Expression.Constant(pid);
                //    var r = Expression.Convert(constant, property.Type);
                //    rightBinary = Expression.MakeBinary(ExpressionType.Equal, property, r);
                //}
                //var binary = Expression.AndAlso(leftBinary, rightBinary);
                //LambdaExpression lambda = Expression.Lambda(binary, parameter);
                //var model = _repositoryEF.GetPage(s => s.Name.Equals(name) && s.Pid == pid, pageIndex.Value, pageSize.Value, out pcount);
                //ViewBag.PageSize = pageSize.Value;
                //ViewBag.TotalCount = pcount;
                //return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }        
        public JsonResult LoadModule()
        {
            var treeViewModels = new List<TreeViewModel>();
            var source = GetTreeViews(_repositoryEF.GetAll(), _repositoryEF.GetAll().Where(s => s.Pid == null), treeViewModels);
            return Json(source);
        }
        private IList<TreeViewModel> GetTreeViews(IQueryable<ModuleEntity> moduleEntities, IQueryable<ModuleEntity> selectEntities, IList<TreeViewModel> treeViewModels)
        {
            foreach (var item in selectEntities)
            {
                var tvm = new TreeViewModel() { id = item.Id, name = item.Name, isParent = false, open = false};
                if (moduleEntities.Count(s => s.Pid == tvm.id) > 0)
                {
                    var child = GetTreeViews(moduleEntities, moduleEntities.Where(s => s.Pid == tvm.id), new List<TreeViewModel>());
                    tvm.children = child;
                    tvm.isParent = true;
                }
                treeViewModels.Add(tvm);
            }
            return treeViewModels;
        }

        public IActionResult Icon()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<ModuleEntity>(model);
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
        public IActionResult Edit(ModuleEntity entities)
        {
            if (ModelState.IsValid)
            {
                _repositoryEF.Update(entities, new List<Expression<Func<ModuleEntity, dynamic>>>()
                    { s=>s.Status,s=>s.CreateTime}
                );
                return RedirectToAction("Index");
            }
            return View(entities);
        }

        public virtual IActionResult Delete(Guid id)
        {
            var isFindchild = _repositoryEF.Count(s => s.Pid == id) > 0;
            if (!isFindchild)
            {
                _repositoryEF.Delete(id);
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            return Json(new { d = false, msg = "该节点存在子节点" });
        }

        public IActionResult ModuleElement(Guid moduleId, int? pageIndex = 1, int? pageSize = 10)
        {
            int pcount;
            var model = _moduleElementRepository.GetPage(s => s.ModuleId == moduleId, pageIndex.Value, pageSize.Value, out pcount);
            ViewBag.PageSize = pageSize.Value;
            ViewBag.TotalCount = pcount;
            ViewBag.moduleId = moduleId;
            return View(model);
        }
        public IActionResult ModuleElementSearch(Guid moduleId, int? pageIndex = 1, int? pageSize = 10)
        {
            int pcount;
            var model = _moduleElementRepository.GetPage(s => s.ModuleId == moduleId, pageIndex.Value, pageSize.Value, out pcount);
            ViewBag.PageSize = pageSize.Value;
            ViewBag.TotalCount = pcount;
            ViewBag.moduleId = moduleId;
            return PartialView("ModuleElementList", model);
        }
        public ActionResult ModuleElementAdd(Guid moduleId)
        {
            ViewBag.moduleId = moduleId;
            return View();
        }

        [HttpPost]
        public ActionResult ModuleElementAdd(ModuleElementViewModel model)
        {
            if (ModelState.IsValid)
            {
                _moduleElementRepository.Insert(_mapper.Map<ModuleElementEntity>(model));
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            ViewBag.moduleId = model.ModuleId;
            return Json(new { d = false });
        }
        public ActionResult ModuleElementEdit(Guid id)
        {
            var model = _moduleElementRepository.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ModuleElementEdit(ModuleElementEntity model)
        {
            if (ModelState.IsValid)
            {
                _moduleElementRepository.Update(model);
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            ViewBag.moduleId = model.ModuleId;
            return Json(new { d = false });
        }

        public IActionResult ModuleElementDelete(Guid id)
        {
            _moduleElementRepository.Delete(id);
            _unitOfWork.Commit();
            return Json(new { d = true });
        }
    }
}

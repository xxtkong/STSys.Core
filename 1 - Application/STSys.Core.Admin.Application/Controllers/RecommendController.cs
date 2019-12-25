using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Data.Context.Interfaces;
using System.Linq.Expressions;
using STSys.Core.Admin.Application.ViewModels;
using Newtonsoft.Json;

namespace STSys.Core.Admin.Application.Controllers
{
    public class RecommendController : BaseContorller
    {
        private readonly IColumnRepository _column;
        private readonly IRepositoryEF<ColumnEntity> _repository;
        private readonly IRepositoryEF<IndexRecommendEntity> _indexRecommend;
        private readonly IUnitOfWork _unitOfWork;
        public RecommendController(IColumnRepository column, IRepositoryEF<ColumnEntity> repository, IUnitOfWork unitOfWork, IRepositoryEF<IndexRecommendEntity> indexRecommendRepository)
        {
            this._column = column;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._indexRecommend = indexRecommendRepository;
        }
        public IActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            var model = CurrentData("", pageIndex, pageSize);
            return View(model);

        }
        private IQueryable<ColumnEntity> CurrentData(string name,int? pageIndex = 1, int? pageSize = 10)
        {
            int pcount;
            var result = _column.GetPage(name, "Sort", out pcount, true, pageIndex.Value, pageSize.Value);
            ViewBag.PageSize = pageSize.Value;
            ViewBag.TotalCount = pcount;
            return result;
        }
        public IActionResult Search(string name,int? pageIndex = 1, int? pageSize = 10)
        {
            var model = CurrentData(name, pageIndex, pageSize);
            return PartialView("List", model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ColumnEntity model)
        {
            if (ModelState.IsValid)
            {
                List<TabsViewModel> list = new List<TabsViewModel>();
                list.Add(new TabsViewModel() { Id = Guid.NewGuid(), Icon = "", Img = "", Intro = "", Name = model.ColumnName, Url = "" });
                model.Tab = JsonConvert.SerializeObject(list);
                model.Status = (int)CommonState.正常;
                model.CreateTime = DateTime.Now;
                _repository.Insert(model);
                _unitOfWork.Commit();
                return Json(new { d = true });
            }
            return Json(new { d = false });
        }

        public IActionResult Edit(Guid id)
        {
            var result = _repository.Find(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ColumnEntity entities)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(entities, new List<Expression<Func<ColumnEntity, dynamic>>>()
                    { s=>s.Status,s=>s.CreateTime,s=>s.Tab}
                );
                return Json(new { d = true });
            }
            return Json(new { d = false });
        }
        public virtual IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
            return Json(new { d = true });
        }

        public virtual IActionResult Settab(Guid cid, int? pageIndex = 1, int? pageSize = 200)
        {
            var column = _repository.Find(cid);
            string tab = column.Tab;
            if (!string.IsNullOrEmpty(tab))
            {
                var listTab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TabsViewModel>>(tab);
                ViewData["listTab"] = listTab;
            }
            int pcount = 0;
            IQueryable<IndexRecommendEntity> model = null;
            switch (column.DataSource.Value)
            {
                case (int)E_Column_DataSource.自定义:
                    model = _indexRecommend.GetPage(s => s.ColumnId.Equals(cid) && s.Type == (int)E_Column_DataSource.自定义, pageIndex.Value, pageSize.Value, out pcount);
                    break;
                default:
                    break;
            }
            ViewBag.PageSize = pageSize.Value;
            ViewBag.TotalCount = pcount;
            ViewBag.cid = column.Id;
            ViewBag.dataSoruce = column.DataSource;
            return View(model);
        }

        /// <summary>
        /// 新增Tab
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="cid"></param>
        /// <returns></returns>

        public ActionResult SaveTab(TabsViewModel viewModel, Guid cid)
        {
            var column = _repository.Find(cid);
            string tab = column.Tab;
            var listTab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TabsViewModel>>(tab);
            if (viewModel.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                viewModel.Id = Guid.NewGuid();
                listTab.Add(viewModel);
            }
            else
            {
                //修改
                var first = listTab.First(s => s.Id == viewModel.Id);
                first.Name = viewModel.Name;
                first.Icon = viewModel.Icon;
                first.Img = viewModel.Img;
                first.Intro = viewModel.Intro;
                first.Url = viewModel.Url;
            }
            column.Tab = Newtonsoft.Json.JsonConvert.SerializeObject(listTab);
            _repository.Update(column);
            _unitOfWork.Commit();
            return Json(true);
        }
       
        public ActionResult DeleteTab(Guid cid, string guid)
        {
            var column = _repository.Find(cid);
            string tab = column.Tab;
            var listTab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TabsViewModel>>(tab);
            if (listTab.Count <= 1)
                return Json(false);
            var first = listTab.First(s => s.Id == Guid.Parse(guid));
            listTab.Remove(first);
            column.Tab = Newtonsoft.Json.JsonConvert.SerializeObject(listTab);
            _repository.Update(column);
            _unitOfWork.Commit();
            Task.Run(() =>
            {
                _indexRecommend.Delete(Guid.Parse(guid));
            });
            return Json(true);
        }

        public ActionResult Rename(Guid cid, string tabId, string newName)
        {
            var column = _repository.Find(cid);
            string tab = column.Tab;
            var listTab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TabsViewModel>>(tab);
            var first = listTab.First(s => s.Id == Guid.Parse(tabId));
            first.Name = newName;
            column.Tab = Newtonsoft.Json.JsonConvert.SerializeObject(listTab);
            _repository.Update(column);
            _unitOfWork.Commit();
            return Json(true);
        }

        public ActionResult GetTab(Guid cid, string tabId)
        {
            var column = _repository.Find(cid);
            string tab = column.Tab;
            var listTab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TabsViewModel>>(tab);
            var first = listTab.First(s => s.Id == Guid.Parse(tabId));
            return Json(first);
        }
        /// <summary>
        /// 自定义页面
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult CustomPage(Guid cid, string guid)
        {
            ViewBag.cid = cid;
            ViewBag.guid = guid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomPage(SelectDataViewModel viewModel, Guid cid, string tabid)
        {
            if (ModelState.IsValid)
            {
                _indexRecommend.Insert(new IndexRecommendEntity() {
                    ColumnId = cid,
                    CreateTime = DateTime.Now,
                    Sort = viewModel.Sort,
                    Type = (int)E_Column_DataSource.自定义,
                    Price = viewModel.Price,
                    Img = viewModel.Img,
                    Intro = viewModel.Intro,
                    TabId = Guid.Parse(tabid),
                    Name = viewModel.Name,
                    Url = viewModel.Url,
                    Status = (int)CommonState.正常
                });
                _unitOfWork.Commit();
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult CustomPageEdit(Guid id)
        {
            var model = _indexRecommend.Find(id);
            var viewModel = new SelectDataViewModel() { Id = model.Id, CategoryId = model.CategoryId, Img = model.Img, Intro = model.Intro, Name = model.Name, Price = model.Price, Sort = model.Sort, TabId = model.TabId.Value, Url = model.Url };
            ViewBag.cid = model.ColumnId;
            ViewBag.tabid = model.TabId.ToString();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CustomPageEdit(SelectDataViewModel viewModel, Guid cid, string tabid)
        {
            if (ModelState.IsValid)
            {
                var model = _indexRecommend.Find(viewModel.Id.Value);
                model.ColumnId = cid;
                model.CreateTime = DateTime.Now;
                model.Sort = viewModel.Sort;
                model.Type = (int)E_Column_DataSource.自定义;
                model.Price = viewModel.Price;
                model.Img = viewModel.Img;
                model.Intro = viewModel.Intro;
                model.TabId = Guid.Parse(tabid);
                model.Name = viewModel.Name;
                model.Url = viewModel.Url;
                _indexRecommend.Update(model);
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult RecommendDelete(Guid id)
        {
            _indexRecommend.Delete(id);
            _unitOfWork.Commit();
            return Json(true);
        }
        
    }
}

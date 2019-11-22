using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.Controllers
{
    public class SysErrorLogController: BaseContorller
    {
        private readonly IRepositoryMongoDB<QueueInfo> _repository;
        public SysErrorLogController(IRepositoryMongoDB<QueueInfo> repository)
        {
            this._repository = repository;
        }
        public IActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            var model = List(pageIndex.Value, pageSize.Value);
            return View(model);
        }

        public IEnumerable<QueueInfo> List(int pageIndex = 1, int pageSize = 10)
        {
            long pcount;
            var result = _repository.GetPage(_ => true, out pcount, null,pageIndex,pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = pcount;
            return result;
        }
       
        public IActionResult Search(int? pageIndex = 1, int? pageSize = 10)
        {
            var model = List(pageIndex.Value, pageSize.Value);
            return PartialView("List", model);
        }
        public virtual IActionResult Delete(string id)
        {
            _repository.Remove(s => s.id == ObjectId.Parse(id));
            return Json(new { d = true });
        }
    }
}

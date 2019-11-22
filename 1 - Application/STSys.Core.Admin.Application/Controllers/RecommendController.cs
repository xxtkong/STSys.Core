using Microsoft.AspNetCore.Mvc;
using STSys.Core.Admin.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using STSys.Core.Admin.Abstractions.Entities;

namespace STSys.Core.Admin.Application.Controllers
{
    public class RecommendController : BaseContorller
    {
        private readonly IColumnRepository _column;
        public RecommendController(IColumnRepository column)
        {
            this._column = column;
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
    }
}

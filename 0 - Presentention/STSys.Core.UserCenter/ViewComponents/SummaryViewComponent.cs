using Microsoft.AspNetCore.Mvc;
using STSys.Core.UserCenter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace STSys.Core.UserCenter.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string msg)
        {
            var model = ApiHelper.Get<IEnumerable<string>>("/api/Notification/Message");
            if (model != null)
            {
                foreach (var item in model)
                {
                    ViewData.ModelState.AddModelError(string.Empty, item);
                }
            }
            return View();
        }
        //public SummaryViewComponent()
        //{

        //}
        //public IViewComponentResult Inovke(int count)
        //{
        //    var model = ApiHelper.Get<IEnumerable<string>>("/api/Notification/Message");
        //    foreach (var item in model)
        //    {
        //        ViewData.ModelState.AddModelError(string.Empty, item);
        //    }
        //    return View();
        //}

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    await Task.FromResult(true);
        //    //var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
        //    //notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

        //    return View();
        //}
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Cache;
using STSys.Core.Domain.Core.Common;
using STSys.Core.DotNettyRPC;
using STSys.Core.File.Abstractions.Entities;
using STSys.Core.File.Abstractions.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Admin.Application.Controllers
{
    [Authorize]
    public class BaseContorller : Controller
    {
        /// <summary>
        /// 登陆用户手机号
        /// </summary>
        public string LoginUserMobile => User.Identity.Name;
        /// <summary>
        /// 获取登录用户Id
        /// </summary>
        public Guid GetLoginUserId => Guid.Parse(HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Sid).Value);

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cacheProvider = new CacheContext();
            IList<LoginRoleDto> mt = cacheProvider.GetCache<IList<LoginRoleDto>>("nav" + GetLoginUserId.ToString());
            string url = Request.Path.Value.ToLower();
            if (url.Split('/').Length == 2)
                url = url + "/index";
            if (string.IsNullOrEmpty(url.Split('/')[2]))
                url = url + "index";
            if (url.Split('/').Length > 3)
                url = url.Split('/')[0] + "/" + url.Split('/')[1] + "/" + url.Split('/')[2];
            var first = mt.YDBSFirst(s => s.modules.URL.ToLower().Equals(url));
            ViewBag.CurrentNav = first == null ? null : first.modules.Id.ToString();
            base.OnActionExecuting(context);
        }

        //private Hashtable extTable = new Hashtable {
        //                           {"image", "gif,jpg,jpeg,png,bmp"},
        //                           {"flash", "swf,flv"},
        //                           {"media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb"},
        //                           {"file", "gif,jpg,jpeg,png,bmp,doc,docx,xls,xlsx,ppt,pptx,htm,html,txt,zip,rar,gz,bz2,pdf"}
        //};
        //private const int imgMaxSize = 3145728;
        //public virtual IActionResult ImageFileUpLoad()
        //{
        //    var files = Request.Form.Files;
        //    long size = files.Sum(f => f.Length);
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            string fileExt = Path.GetExtension(formFile.FileName);
        //            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable["file"]).Split(','), fileExt.Substring(1).ToLower()) == -1)
        //                return new JsonResult(new { d = false, msg = "上传文件扩展名是不允许的扩展名" });
        //            long fileSize = formFile.Length;
        //            string newFileName = System.Guid.NewGuid().ToString() + fileExt;
        //            if (size > imgMaxSize)
        //                return new JsonResult(new { d = false, msg = "上传文件大小超过限制" });
        //            var stream = formFile.OpenReadStream();
        //            byte[] btye = StreamToBytes(stream);
        //            var client = RPCClientFactory.GetClient<IFileUpLoad>("127.0.0.1", 9999);
        //            string msg = client.ImagesUpLoad(new Identify() { FileName = newFileName, fs = btye, Project = "STSys" });
        //            return new JsonResult(new { d = true, msg = msg });
        //        }
        //    }
        //    return new JsonResult(new { d = false, msg = "上传失败" });
        //}

        //private byte[] StreamToBytes(Stream stream)
        //{
        //    var bytes = new byte[stream.Length];
        //    stream.Read(bytes, 0, bytes.Length);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    return bytes;
        //}
    }
}

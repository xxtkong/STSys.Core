using Microsoft.AspNetCore.Mvc;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.File.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace STSys.Core.FileWeb.Controllers
{
    public class ImagesController: Controller
    {
        private readonly IRepositoryMongoDB<ImagesEntity> _repositoryMongo;
        public ImagesController(IRepositoryMongoDB<ImagesEntity> repositoryMongo)
        {
            this._repositoryMongo = repositoryMongo;
        }
        /// <summary>
        /// 获取图片文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string id)
        {
            #region 设置浏览器缓存header头信息
            Response.Headers.Add("Cache-Control", "pulic");
            Response.Headers.Add("Last-Modified", DateTime.Now.AddDays(-30).ToString("r"));
            Response.Headers.Add("Expires", DateTime.Now.AddDays(30).ToString("r"));
            #endregion
            if (string.IsNullOrWhiteSpace(id))
            {
                //返回404信息
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            var result = await _repositoryMongo.Get(s => s.Id.Equals(id));
            if(result == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            var fileStream = new FileStream(result.Address, FileMode.Open, FileAccess.Read);
            var buffur = new byte[fileStream.Length];
            fileStream.Read(buffur, 0, (int)fileStream.Length);
            fileStream.Close();
            var fileResult = new FileContentResult(buffur, "image/jpeg");
            return fileResult;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using STSys.Core.DotNettyRPC;
using STSys.Core.File.Abstractions.Entities;
using STSys.Core.File.Abstractions.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSys.Core.Admin.Application.Controllers
{
    public class ToolController: Controller
    {
        private Hashtable extTable = new Hashtable {
                                   {"image", "gif,jpg,jpeg,png,bmp"},
                                   {"flash", "swf,flv"},
                                   {"media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb"},
                                   {"file", "gif,jpg,jpeg,png,bmp,doc,docx,xls,xlsx,ppt,pptx,htm,html,txt,zip,rar,gz,bz2,pdf"}
        };
        private const int imgMaxSize = 3145728;
        public IActionResult FileUpLoad()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = Path.GetExtension(formFile.FileName);
                    if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable["file"]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                        return new JsonResult(new { d = false, msg = "上传文件扩展名是不允许的扩展名" });
                    long fileSize = formFile.Length;
                    string newFileName = System.Guid.NewGuid().ToString() + fileExt;
                    if (size > imgMaxSize)
                        return new JsonResult(new { d = false, msg = "上传文件大小超过限制" });
                    var stream = formFile.OpenReadStream();
                    byte[] btye = StreamToBytes(stream);
                    var client = RPCClientFactory.GetClient<IFileUpLoad>("127.0.0.1", 9999);
                    string msg = client.ImagesUpLoad(new Identify() { FileName = newFileName, fs = btye, Project = "STSys" });
                    return new JsonResult(new { d = true, msg = msg });
                }
            }
            return new JsonResult(new { d = false, msg = "上传失败" });
        }

        private byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}

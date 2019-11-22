using Microsoft.Extensions.Options;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.File.Abstractions.Entities;
using STSys.Core.File.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace STSys.Core.Files.Service
{
    public class FileUpLoad : IFileUpLoad
    {
        string pathService = AppContext.BaseDirectory;
        public string ImagesUpLoad(Identify identify)
        {
            if (!string.IsNullOrEmpty(Settings.Address))
                pathService = Settings.Address;
            if (string.IsNullOrEmpty(identify.FileName))
                identify.FileName = Guid.NewGuid().ToString().Replace("-", "");
            if (string.IsNullOrEmpty(identify.Project))
                identify.Project = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd");
            else
                identify.Project = identify.Project + "/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd");
            var project = identify.Project;
            identify.Project  =pathService + "/" + project;
            if (!Directory.Exists(identify.Project))
                Directory.CreateDirectory(identify.Project);
            try
            {
                MemoryStream ms = new MemoryStream(identify.fs);
                FileStream saveFile = new FileStream(identify.Project + "/" + identify.FileName + ".jpg", FileMode.Create);
                ms.WriteTo(saveFile);
                ms.Close();
                saveFile.Close();
                ms.Dispose();
                saveFile.Dispose();
                var id = Guid.NewGuid().ToString();
                string webfileUrl = Settings.WebFile +"/"+ project + "/" + identify.FileName + ".jpg";
                Task.Run(() =>
                {
                    try
                    {
                        var images = Settings.serviceProvider.GetService<IRepositoryMongoDB<ImagesEntity>>();
                        images.Add(new ImagesEntity() { Address = identify.Project + "/" + identify.FileName + ".jpg", CreateTime = DateTime.Now, Id = id, WebfileUrl = webfileUrl });
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                });
                return webfileUrl;
            }
            catch (ArgumentNullException e)
            {
                return e.Message;
                throw;
            }
        }
    }
}

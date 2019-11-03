using InOne.TaskManager.Models.OtherModels;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace InOne.TaskManager.Api.Controllers
{
    public class AttachmentController : BaseController
    {

        [HttpPost, Route("attachment")]
        public string UploadFile()
        {
            const string FilesPath = @"~\uploads\";
            bool exists = Directory.Exists(HttpContext.Current.Server.MapPath(FilesPath));
            if (!exists)
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FilesPath));
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(FilesPath), fileName);
                file.SaveAs(path + fileName);
            }
            return file != null ? FilesPath + file.FileName : null;
        }
    }
}

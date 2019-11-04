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
        public IHttpActionResult PostAttachment(int taskId)
        {
            string[] file = Uploader.UploadFile();
            UnitOfWork.AttachmentManager.AddAttachment(new AttachmentAdd {  Location = file[0], Name = file[1], TaskId = taskId});
            UnitOfWork.Commit();
            return Ok(HttpStatusCode.Created);
        }
    }
}

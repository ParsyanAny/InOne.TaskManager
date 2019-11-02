using InOne.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InOne.TaskManager.Api.Controllers
{
    public class AttachmentController : BaseController
    {
        [HttpPost, Route("attachment")]
        public IHttpActionResult PostAttachment(Attachment attachment)
        {
            UnitOfWork.AttachmentManager.AddAttachment(attachment);
            UnitOfWork.Commit();
            return Json("Success");
        }
    }
}

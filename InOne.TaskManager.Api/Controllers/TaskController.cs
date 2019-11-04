using InOne.Reservation.Manager.IMPL;
using InOne.TaskManager.Models.OtherModels;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace InOne.TaskManager.Api.Controllers
{
    [BasicAuthentication]
    public class TaskController : BaseController
    {
        [HttpGet, Route("task")]
        public HttpResponseMessage GetTasks() => GetUserTasksInfoFile();

        [HttpPost, Route("task")]
        public IHttpActionResult PostUser(TaskAdd task)
        {
            task.CreatorId = AuthHelper.Id;
            UnitOfWork.TaskManager.AddTask(task);
            UnitOfWork.Commit();
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut, Route("deletetask")]
        public IHttpActionResult PutTask(int taskId)
        {
            UnitOfWork.TaskManager.DeleteSaveLog(taskId);
            return Ok(HttpStatusCode.Accepted);
        }

        [HttpPut, Route("changestatus")]
        public IHttpActionResult PutTaskStatus(int taskId, int statusId)
        {
            UnitOfWork.TaskManager.ChangeSaveLogStatus(taskId, AuthHelper.Id, statusId);
            return Ok(HttpStatusCode.Accepted);
        }
        [HttpPut, Route("changetask")]
        public IHttpActionResult PutTask(TaskChange task)
        {
            UnitOfWork.TaskManager.ChangeSaveLogTask(task);
            return Ok(HttpStatusCode.Accepted);
        }

    }
}
using InOne.Reservation.Manager.IMPL;
using InOne.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InOne.TaskManager.Api.Controllers
{
    public class TaskController : BaseController
    {
        [BasicAuthentication]
        [HttpGet, Route("task")]
        public IHttpActionResult GetTasks(int userId) => Json(UnitOfWork.TaskManager.GetTask(userId));
        [BasicAuthentication]
        [HttpPost, Route("task")]
        public IHttpActionResult GetUserInfo(Task task)
        {
            UnitOfWork.TaskManager.AddTask(task);
            UnitOfWork.Commit();
            return Json("Success");
        }
        [BasicAuthentication]
        [HttpPut, Route("deletetask")]
        public IHttpActionResult PutTask(int taskId)
        {
            var create = _context.Tasks.Find(taskId).CreateDate;
            Logging.WriteLog($"DeletedId = {taskId}, CreateDate = {create}");
            UnitOfWork.TaskManager.DeleteTask(taskId);
            UnitOfWork.Commit();
            return Json("Success");
        }
        [HttpPut, Route("changestatus")]
        public IHttpActionResult PutTaskStatus(int taskId, int statusId)
        {
            Task task = _context.Tasks.Find(taskId);
            Logging.WriteLog($"Id = {taskId}, CreateDate = {task.CreateDate}");
            UnitOfWork.TaskManager.ChangeStatus(taskId, AuthHelper.Id, statusId);
            UnitOfWork.Commit();
            return Json("Success");
        }
    }
}
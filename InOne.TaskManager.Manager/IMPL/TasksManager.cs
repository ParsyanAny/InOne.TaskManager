using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static InOne.TaskManager.Entities.Enums;

namespace InOne.TaskManager.Manager.IMPL
{
    public class TasksManager : BaseManager<Task, TaskModel>, ITaskManager
    {
        public TasksManager(ApplicationContext context) : base(context) { }


        public void AddTask(TaskAdd taskAdd) => Add(addTaskToEntity(taskAdd));
        public void ChangeStatus(int taskId, int userId, int statusId)
        {
            var task = GetEntity(taskId);

            if (task.CreatorId == userId && task.Status == Status.Completed && statusId != 1)
                task.Status = (statusId == 3) ? Status.Closed : Status.Rejected;
            if (task.AssignedId == taskId && statusId == 2)
            {
                if (task.Status == Status.Open || task.Status == Status.Rejected)
                    task.Status = Status.Completed;
            }
        }
        public void ChangeTask(TaskChange task)
        {
            var result = GetEntity(task.Id);
            if (result != null)
            {
                result.Title = task.Title;
                result.Description = task.Description;
                result.AssignedId = task.AssignedId;
            }
        }

        public void ChangeSaveLogTask(TaskChange task)
        {
            ChangeTask(task);
            _context.SaveChanges();
            Logger(task.Id);
        }
        public void ChangeSaveLogStatus(int taskId, int userId, int statusId)
        {
            ChangeStatus(taskId, userId, statusId);
            _context.SaveChanges();
            Logger(taskId);
        }

        public List<TaskInfo> GetTasks(int userId)
        {
            User creator = _context.Users.Find(userId);
            var tasks = _context.Tasks.Where(p => p.CreatorId == userId).ToList();
            var result = new List<TaskInfo>();
            foreach (var item in tasks)
            {
                result.Add(new TaskInfo
                {
                    TaskName = item.Title,
                    ExpireDate = item.ExpirationDate,
                    CreateDate = item.CreateDate,
                    AssignedFirstName = creator.FirstName,
                    AssignedLastName = creator.LastName,
                    AttachmentCount = _context.Attachments.Where(p=> p.TaskId == item.Id).Count(),
                    Description = item.Description,
                    StatusId = item.Status
                });
            }
            return result;
        }

        #region TaskModel -> Task, Task -> TaskModel
        public override Task ModelToEntity(TaskModel model)
            => new Task
            {
                Id = model.Id,
                AssignedId = model.AssignedId,
                CreatorId = model.CreatorId,
                Status = model.StatusId,
                Title = model.Title,
                Description = model.Description,
                Deleted = model.Deleted,
                CreateDate = model.CreateDate,
                ExpirationDate = model.ExpirationDate,
                //AttachmentIds = model.AttachmentIds
            };
        public override TaskModel EntityToModel(Task entity)
            => new TaskModel
            {
                Id = entity.Id,
                AssignedId = entity.AssignedId,
                CreatorId = entity.CreatorId,
                StatusId = entity.Status,
                Title = entity.Title,
                Description = entity.Description,
                Deleted = entity.Deleted,
                CreateDate = entity.CreateDate,
                ExpirationDate = entity.ExpirationDate
            };
        private Task addTaskToEntity(TaskAdd taskAdd)
            => new Task
            {
                Title = taskAdd.Title,
                Description = taskAdd.Description,
                AssignedId = taskAdd.AssignedId,
                CreatorId = taskAdd.CreatorId,
                CreateDate = DateTime.Now,
                Status = Status.Open,
                Deleted = false,
                ExpirationDate = taskAdd.ExpirationDate,
            };
        #endregion
    }
}

using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;
using System.Collections.Generic;
using System.Linq;

namespace InOne.TaskManager.Manager.IMPL
{
    public class TasksManager : BaseManager<Task, TaskModel>, ITaskManager
    {
        public TasksManager(ApplicationContext context) : base(context) { }

        public void AddTask(Task task) => _context.Tasks.Add(task);
        public void ChangeStatus(int taskId, int userId, int statusId)
        {
            var user = _context.Users.Find(userId);
            var task = _context.Tasks.Find(taskId);
            if (task.CreatorId == taskId && task.StatusId == 2 && statusId != 1)
                task.StatusId = statusId;
            if (task.AssignedId == taskId)
            {
                if (task.StatusId == 1 && statusId == 1)
                    task.StatusId = statusId;
                if (task.StatusId == 4 && statusId == 2)
                    task.StatusId = statusId;
            }
        }
        public void ChangeTask(string title, string description, int assignedId, int taskId)
        {
            var result = _context.Tasks.Find(taskId);
            if (result != null)
            {
                result.Title = title;
                result.Description = description;
                result.AssignedId = assignedId;
            }
            _context.SaveChanges();
        }
        public void DeleteTask(int Id)
        {
            Task task = _context.Tasks.Find(Id);
            if (task != null)
                task.Deleted = true;
        }
        public List<TaskInfo> GetTask(int userId)
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
                    AttachmentCount = item.AttachmentIds.Count(),
                    Description = item.Description,
                    StatusId = item.StatusId
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
                StatusId = model.StatusId,
                Title = model.Title,
                Description = model.Description,
                Deleted = model.Deleted,
                CreateDate = model.CreateDate,
                ExpirationDate = model.ExpirationDate,
                AttachmentIds = model.AttachmentIds
            };
        public override TaskModel EntityToModel(Task entity)
            => new TaskModel
            {
                Id = entity.Id,
                AssignedId = entity.AssignedId,
                CreatorId = entity.CreatorId,
                StatusId = entity.StatusId,
                Title = entity.Title,
                Description = entity.Description,
                Deleted = entity.Deleted,
                CreateDate = entity.CreateDate,
                ExpirationDate = entity.ExpirationDate,
                AttachmentIds = entity.AttachmentIds
            };
        #endregion
    }
}

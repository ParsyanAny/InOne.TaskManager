using System;
using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;

namespace InOne.TaskManager.Manager.IMPL
{
    public class TasksManager : BaseManager<Task, TaskModel>, ITaskManager
    {
        public TasksManager(ApplicationContext context) : base(context) { }

        public void AddTask(Task task) => _context.Tasks.Add(task);
        public void ChangeStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public void ChangeTask(string name, string description, int assignedId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int Id)
        {
            throw new NotImplementedException();
        }
        public TaskInfo GetTask(int userId)
        {
            throw new NotImplementedException();
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

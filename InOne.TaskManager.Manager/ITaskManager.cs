using InOne.TaskManager.Entities;
using InOne.TaskManager.Models.OtherModels;
using System.Collections.Generic;

namespace InOne.TaskManager.Manager
{
    public interface ITaskManager
    {
        void AddTask(Task task);
        void ChangeTask(string name, string description, int assignedId, int taskId);
        void ChangeStatus(int taskId, int userId, int statusId);
        void DeleteTask(int Id);
        List<TaskInfo> GetTask(int userId); 
    }
}

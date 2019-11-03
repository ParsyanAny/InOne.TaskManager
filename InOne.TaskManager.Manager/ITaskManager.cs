using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;
using System.Collections.Generic;

namespace InOne.TaskManager.Manager
{
    public interface ITaskManager : IBaseManager<Task, TaskModel>
    {
        void AddTask(TaskAdd task);
        void ChangeTask(TaskChange task);
        void ChangeSaveLogTask(TaskChange task);
        void ChangeStatus(int taskId, int userId, int statusId);
        void ChangeSaveLogStatus(int taskId, int userId, int statusId);
        List<TaskInfo> GetTask(int userId); 
    }
}

using InOne.TaskManager.Entities;
using InOne.TaskManager.Models.OtherModels;

namespace InOne.TaskManager.Manager
{
    public interface ITaskManager
    {
        void AddTask(Task task);
        void ChangeTask(string name, string description, int assignedId);
        void ChangeStatus(int statusId);
        void DeleteTask(int Id);
        TaskInfo GetTask(int userId); 
    }
}

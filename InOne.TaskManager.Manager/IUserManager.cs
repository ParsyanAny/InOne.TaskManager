using InOne.TaskManager.Entities;
using InOne.TaskManager.Models.OtherModels;
using System;

namespace InOne.TaskManager.Manager
{
    public interface IUserManager
    {
        void AddUser(User user);
        void ChangeUser(UserChange user);
        void DeleteUser(int Id);
        UserInfo GerUserInfo(int userId);
    }
}

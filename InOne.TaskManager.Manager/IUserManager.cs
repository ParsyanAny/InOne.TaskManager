using InOne.TaskManager.Entities;
using InOne.TaskManager.Models.OtherModels;
using System;

namespace InOne.TaskManager.Manager
{
    public interface IUserManager
    {
        void AddUser(User user);
        void ChangeUser(string FirstName, string LastName, DateTime birthday, string password);
        void DeleteUser(int Id);
        UserInfo GerUserInfo(int userId);
    }
}

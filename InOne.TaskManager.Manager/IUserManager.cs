using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;

namespace InOne.TaskManager.Manager
{
    public interface IUserManager : IBaseManager<User, UserModel>
    {
        void AddUser(UserAdd user);
        void ChangeUser(UserChange user, int Id);
        void ChangeUserSaveLog(UserChange user, int Id);
        UserInfo GerUserInfo(int userId);
    }
}

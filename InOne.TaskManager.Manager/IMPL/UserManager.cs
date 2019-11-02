using System;
using System.Linq;
using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;

namespace InOne.TaskManager.Manager.IMPL
{
    public class UserManager : BaseManager<User, UserModel>, IUserManager
    {
        public UserManager(ApplicationContext context) : base(context) { }

        public void AddUser(User user) => _context.Users.Add(user);
        public void ChangeUser(UserChange user)
        {
            var result = _context.Users.Find(user.Id);
            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.BirthDay = user.BirthDay;
                result.Password = user.Password;
            }
        }

        public void DeleteUser(int Id) => _context.Users.Find(Id).Deleted = true;

        public UserInfo GerUserInfo(int userId)
        {
            var currentUser = _context.Users.Find(userId);
            var res = from task in _context.Tasks
                      join user in _context.Users.Where(p => p.Id == userId) on task.AssignedId equals user.Id
                      //group task by user into Tasks
                      select new TaskInfo
                      {
                          TaskName = task.Title,
                          StatusId = task.StatusId,
                          CreateDate = task.CreateDate,
                          Description = task.Description,
                          ExpireDate = task.ExpirationDate,
                          AttachmentCount = 1,
                          AssignedFirstName = user.FirstName,
                          AssignedLastName = user.LastName

                      };
            return new UserInfo
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Birthday = currentUser.BirthDay,
                UserName = currentUser.UserName,
                TaskInfos = res.ToList()
            };
        }
        #region UserModel -> User, User -> UserModel
        public override UserModel EntityToModel(User entity)
            => new UserModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDay = entity.BirthDay,
                Deleted = entity.Deleted,
                RegistrationDate = entity.RegistrationDate,
                GenderId = entity.GenderId
            };
        public override User ModelToEntity(UserModel model)
            => new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDay = model.BirthDay,
                Deleted = model.Deleted,
                RegistrationDate = model.RegistrationDate,
                GenderId = model.GenderId,

            };
        #endregion
    }
}

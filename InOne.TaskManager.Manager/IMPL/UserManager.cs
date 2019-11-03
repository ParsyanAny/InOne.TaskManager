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

        public void AddUser(UserAdd model)
        {
            if (CheckUserName(model.UserName))
                throw new Exception("Please enter another UserName");
            User user = addModelToUser(model);
            Add(user);
        }

        public void ChangeUser(UserChange user, int userId)
        {
            var result = GetEntity(userId);
            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.BirthDay = user.BirthDay;
                result.Password = user.Password;
            }
        }
        public void ChangeUserSaveLog(UserChange user, int userId)
        {
            ChangeUser(user, userId);
            _context.SaveChanges();
            Logger(userId);

        }
        public UserInfo GerUserInfo(int userId)
        {
            var currentUser = GetEntity(userId);
            var res = from task in _context.Tasks
                      join user in _context.Users.Where(p => p.Id == userId) on task.AssignedId equals user.Id
                      select new TaskInfo
                      {
                          TaskName = task.Title,
                          StatusId = task.Status,
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

        private bool CheckUserName(string userName)
           => _context.Users.Where(p => p.UserName == userName).FirstOrDefault() != null;
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
                GenderId = entity.Gender
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
                Gender = model.GenderId,

            };
        private User addModelToUser(UserAdd model)
            => new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                BirthDay = model.BirthDay,
                Deleted = false,
                Gender = model.Gender,
                RegistrationDate = DateTime.Now
            };
        #endregion
    }
}

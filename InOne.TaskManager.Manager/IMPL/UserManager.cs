using System;
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
        public void ChangeUser(string FirstName, string LastName, DateTime birthday, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int Id)
        {
            throw new Exception();
        }
        public UserInfo GerUserInfo(int userId)
        {
            throw new NotImplementedException();
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

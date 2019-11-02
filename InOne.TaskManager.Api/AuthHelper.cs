using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using System.Linq;

namespace InOne.TaskManager.Api
{
    public static class AuthHelper
    {
        static public int Id;
        static public bool Search(string userName, string password)
        {
            ApplicationContext context = new ApplicationContext();
            User currentUser = context.Users.Where(p => p.UserName == userName && p.Password == password).FirstOrDefault();
            if (currentUser != null)
            {
                Id = currentUser.Id;
            }
            return false;
        }
    }
}
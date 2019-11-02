using InOne.TaskManager.Entities;
using InOne.TaskManager.Models.OtherModels;
using System.Web.Http;

namespace InOne.TaskManager.Api.Controllers
{
    public class UserController : BaseController
    {

        [BasicAuthentication]
        [HttpGet, Route("userinfo")]
        public IHttpActionResult GetUserInfo()
            => Json(UnitOfWork.UserManager.GerUserInfo(AuthHelper.Id));

        [HttpPost, Route("user")]
        public IHttpActionResult PostUser([FromBody]User user)
        {
            UnitOfWork.UserManager.AddUser(user);
            UnitOfWork.Commit();
            return Json("Success");
        }
        [BasicAuthentication]
        [HttpPut, Route("user")]
        public IHttpActionResult PutUser(UserChange user)
        {
            var create = _context.Users.Find(user.Id).RegistrationDate;
            Logging.WriteLog($" Changed Id {user.Id} RegistrationDate{create}");
            UnitOfWork.UserManager.ChangeUser(user);
            UnitOfWork.Commit();
            return Json("Success");
        }
        [BasicAuthentication]
        [HttpPut, Route("deleteuser")]
        public IHttpActionResult PutUser()
        {
            UnitOfWork.UserManager.DeleteUser(AuthHelper.Id);
            UnitOfWork.Commit();
            return Json("Success");
        }
    }
}

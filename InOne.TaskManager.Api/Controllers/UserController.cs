using InOne.TaskManager.Models.OtherModels;
using System.Net;
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
        public IHttpActionResult PostUser([FromBody]UserAdd user)
        {
            UnitOfWork.UserManager.AddUser(user);
            UnitOfWork.Commit();
            return Ok(HttpStatusCode.Created);
        }
        [BasicAuthentication]
        [HttpPut, Route("user")]
        public IHttpActionResult PutUser(UserChange user)
        {
            UnitOfWork.UserManager.ChangeUserSaveLog(user, AuthHelper.Id);
            UnitOfWork.Commit();
            return Ok(HttpStatusCode.Accepted);
        }
        [BasicAuthentication]
        [HttpPut, Route("deleteuser")]
        public IHttpActionResult PutUser()
        {
            UnitOfWork.UserManager.DeleteSaveLog(AuthHelper.Id);
            UnitOfWork.Commit();
            return Ok(HttpStatusCode.OK);
        }
    }
}

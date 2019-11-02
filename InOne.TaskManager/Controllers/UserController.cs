using InOne.TaskManager.Entities;
using System.Web.Http;

namespace InOne.TaskManager.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost, Route("user")]
        public IHttpActionResult PostOrder([FromBody]User user)
        {
            UnitOfWork.UserManager.AddUser(user);
            return Json("Success");
        }
    }
}

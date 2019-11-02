using InOne.Reservation.Manager.IMPL;
using InOne.TaskManager.DataAccessLayer;
using System.Web.Http;

namespace InOne.TaskManager.Controllers
{
    public class BaseController : ApiController
    {
        protected ApplicationContext _context = new ApplicationContext();
        protected UnitOfWork UnitOfWork => new UnitOfWork(_context);
    }
}
using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BookShop
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {

        private const string Realm = "My Realm";
        public override void OnAuthorization(HttpActionContext actContext)
        {
            if (actContext.Request.Headers.Authorization == null)
            {
                actContext.Response = actContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                if (actContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                    actContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
            else
            {
                string authenticationToken = actContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePassword = decodedAuthenticationToken.Split(':');
                string username = usernamePassword[0];
                string password = usernamePassword[1];
                
                if (Search(username,password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = principal;
                }
                else
                    actContext.Response = actContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        private bool Search(string userName, string password)
        {
            ApplicationContext context = new ApplicationContext();
            User currentUser = context.Users.Where(p => p.UserName == userName && p.Password == password).FirstOrDefault();
            return currentUser != null;
        }
    }
}
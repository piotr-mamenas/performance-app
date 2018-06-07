using System.Web;
using System.Web.Http;
using Core.Domain.Identity;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Service.Controllers
{
    public class BaseApiController : ApiController
    {
        private User _currentUser;

        protected User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    _currentUser = userManager.FindByNameAsync(HttpContext.Current.User.Identity.Name).Result;
                }
                return _currentUser;
            }
        }
    }
}
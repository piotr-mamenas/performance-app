using System.Web.Mvc;
using Core.Interfaces;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("")]
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Login", "Authentication");
        }
    }
}

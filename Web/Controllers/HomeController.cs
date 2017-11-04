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
        public HomeController(ILogger logger)
            : base(logger)
        {
        }

        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Authentication");
        }
    }
}

using System;
using System.Web.Mvc;
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
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex,$"{ex} occurred");
            }

            return RedirectToAction("Login", "Authentication");
        }
    }
}

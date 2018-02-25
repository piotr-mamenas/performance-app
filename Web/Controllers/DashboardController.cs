using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        public DashboardController(ILogger logger)
            : base(logger)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
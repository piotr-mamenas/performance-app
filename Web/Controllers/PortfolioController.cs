using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("portfolios")]
    public class PortfolioController : BaseController
    {
        public PortfolioController(ILogger logger)
            : base(logger)
        {    
        }

        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("list")]
        public ActionResult List()
        {
            return View();
        }
    }
}
using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("partners")]
    [Authorize]
    public class PartnerController : BaseController
    {
        public PartnerController(ILogger logger)
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
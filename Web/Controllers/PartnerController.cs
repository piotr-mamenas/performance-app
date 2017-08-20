using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("partners")]
    public class PartnerController : BaseController
    {
        public PartnerController(ILogger logger)
            : base(logger)
        {    
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
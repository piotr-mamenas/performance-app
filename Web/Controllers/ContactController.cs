using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("contacts")]
    public class ContactController : BaseController
    {
        public ContactController(ILogger logger)
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
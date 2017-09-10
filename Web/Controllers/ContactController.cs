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

        [Route("list")]
        public ActionResult List()
        {
            return View();
        }

        [Route("new")]
        public ActionResult NewContact()
        {
            return View();
        }
    }
}
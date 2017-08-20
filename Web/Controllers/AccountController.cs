using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountController : BaseController
    {
        public AccountController(ILogger logger)
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
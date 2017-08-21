using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("tasks")]
    public class TaskController : BaseController
    {
        public TaskController(ILogger logger)
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
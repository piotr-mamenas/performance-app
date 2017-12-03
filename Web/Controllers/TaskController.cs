using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("tasks")]
    [Authorize]
    public class TaskController : BaseController
    {
        public TaskController(ILogger logger)
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

        [Route("schedule")]
        public ActionResult ShowSchedule()
        {
            return View();
        }
    }
}
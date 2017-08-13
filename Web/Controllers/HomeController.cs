using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

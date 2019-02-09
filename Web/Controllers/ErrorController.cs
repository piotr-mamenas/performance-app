using System.Web.Mvc;

namespace Web.Controllers
{
    [RoutePrefix("error")]
    public class ErrorController : Controller
    {
        [Route("notfound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        [Route("forbidden")]
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        [Route("unauthorized")]
        public ActionResult Unauthorized()
        {
            Response.StatusCode = 401;
            return View();
        }

        [Route("internal")]
        public ActionResult Internal()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}
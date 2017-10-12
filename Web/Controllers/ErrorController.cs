using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("error")]
    public class ErrorController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("notfound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("forbidden")]
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("unauthorized")]
        public ActionResult Unauthorized()
        {
            Response.StatusCode = 401;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("internal")]
        public ActionResult Internal()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}
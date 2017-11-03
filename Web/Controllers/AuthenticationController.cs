using System.Web.Mvc;
using Core.Interfaces;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("login")]
    public class AuthenticationController : BaseController
    {
        private readonly IComplete _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public AuthenticationController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete)unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}
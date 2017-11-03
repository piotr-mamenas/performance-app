using System.Web.Mvc;
using Core.Interfaces;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [RoutePrefix("")]
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        private readonly IUnitOfWork _unitOfWork;
    }
}

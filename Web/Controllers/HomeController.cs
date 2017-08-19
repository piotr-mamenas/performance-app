using System.Web.Mvc;
using Core.Interfaces;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IUnitOfWork unitOfWork)
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

using System.Web.Mvc;
using Core.Domain.Organization;
using Core.Domain.Partner;
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
            ViewBag.Title = "Home Page";

            var newOrganization = new BaseOrganization()
            {
                Name = "Post Finance"
            };

            _unitOfWork.Organizations.Add(newOrganization);

            var newPartner = new BasePartner
            {
                Name = "Partner",
                Number = "P0123"
            };

            _unitOfWork.Partners.Add(newPartner);
            _unitOfWork.Complete();

            return View();
        }

        private readonly IUnitOfWork _unitOfWork;
    }
}

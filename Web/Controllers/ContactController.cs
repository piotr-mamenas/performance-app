using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Contacts;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.Contact;

namespace Web.Controllers
{
    [RoutePrefix("contacts")]
    public class ContactController : BaseController
    {
        private readonly IContactRepository<Contact> _repository;
        private readonly IComplete _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Contacts;
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

        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(NewContactViewModel contactViewModel)
        {
            return View();
        }

        [HttpGet]
        [Route("new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("new")]
        public ActionResult New(NewContactViewModel contactViewModel)
        {
            return RedirectToAction("List");
        }

        /*
        [Route("edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var contactInDb = await _repository.GetAsync(id);

            if (contactInDb == null)
            {
                return RedirectToAction("List");
            }

            // Temporary solution before I move automapper to a separate assembly, atm adjusting mapper would cause circular
            // dependency infra <=> web
            var temporaryContactDetailViewModel = new NewContactViewModel
            {
                Email = contactInDb.Email,
                FirstName = contactInDb.FirstName,
                LastName = contactInDb.LastName,
                Name = contactInDb.Name,
                PhoneNumber = contactInDb.PhoneNumber
            };

            return View();
        }
        */
    }
}
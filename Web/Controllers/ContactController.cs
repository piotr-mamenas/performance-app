using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Contacts;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Serialization.JsonContractResolvers;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.DetailViews.ProductDetailViews;

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

        [Route("list")]
        public ActionResult List()
        {
            return View();
        }

        [Route("new")]
        public ActionResult NewContact()
        {
            return View();
        }

        [Route("edit/{id}")]
        public async Task<ActionResult> EditContact(int id)
        {
            var contactInDb = await _repository.GetAsync(id);

            if (contactInDb == null)
            {
                return RedirectToAction("List");
            }

            // Temporary solution before I move automapper to a separate assembly, atm adjusting mapper would cause circular
            // dependency infra <=> web
            var temporaryContactDetailViewModel = new ContactDetailViewModel
            {
                Email = contactInDb.Email,
                FirstName = contactInDb.FirstName,
                LastName = contactInDb.LastName,
                Name = contactInDb.Name,
                PhoneNumber = contactInDb.PhoneNumber
            };

            return View(temporaryContactDetailViewModel);
        }
    }
}
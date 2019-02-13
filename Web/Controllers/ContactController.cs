using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Contacts;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.ContactViewModels;

namespace Web.Controllers
{
    [RoutePrefix("contacts")]
    [Authorize]
    public class ContactController : BaseController
    {
        private readonly IContactRepository _contactRepository;
        private readonly IPartnerRepository _partnerRepository;

        public ContactController(IUnitOfWork unitOfWork, 
            IContactRepository contactRepository, 
            IPartnerRepository partnerRepository, 
            ILogger logger)
            : base(logger, unitOfWork)
        {
            _contactRepository = contactRepository;
            _partnerRepository = partnerRepository;
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
        [Route("create")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new ContactViewModel
            {
                PartnerNumberSelection = await GetPartnerSelection()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(ContactViewModel contactVm)
        {
            if (!ModelState.IsValid)
            {
                contactVm.PartnerNumberSelection = await GetPartnerSelection();
                return View(contactVm);
            }

            _contactRepository.Add(contactVm.Map<Contact>());

            await UnitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {
            var contactInDb = await _contactRepository.GetAsync(id);

            if (contactInDb == null)
            {
                return View("List");
            }

            var contactVm = contactInDb.Map<ContactViewModel>();

            contactVm.PartnerNumberSelection = await GetPartnerSelection();

            return View(contactVm);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, ContactViewModel contactVm)
        {
            if (!ModelState.IsValid)
            {
                return View(contactVm);
            }

            var contactInDb = await _contactRepository.GetAsync(id);

            if (contactInDb == null)
            {
                return View(contactVm);
            }

            contactInDb = contactVm.Map<Contact>();

            _contactRepository.Add(contactInDb);

            await UnitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        private async Task<IEnumerable<SelectListItem>> GetPartnerSelection()
        {
            var partners = await _partnerRepository.GetAllPartnersAsync();

            if (partners != null)
            {
                var selectList = partners.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Number
                });
                return new SelectList(selectList, "Value", "Text");
            }
            return new SelectList(null, "Value", "Text");
        }
    }
}
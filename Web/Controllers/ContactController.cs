using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Contacts;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.AutoMapper;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.ContactViewModels;

namespace Web.Controllers
{
    [RoutePrefix("contacts")]
    public class ContactController : BaseController
    {
        private readonly IContactRepository<Contact> _contacts;
        private readonly IPartnerRepository<Partner> _partners;
        private readonly IComplete _unitOfWork;

        /// <summary>
        /// Default constructor with injected components
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public ContactController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _contacts = unitOfWork.Contacts;
            _partners = unitOfWork.Partners;
        }

        /// <summary>
        /// Index present for compatibility, it will automatically redirect to List
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// Method listing the contacts in a datatable, load is handled with ajax hence no return
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// Method will return a clean create contact view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var viewModel = new ContactViewModel
            {
                PartnerNumberSelection = GetPartnerSelection()
            };

            return View(viewModel);
        }

        /// <summary>
        /// Method will create a new contact with the signature of contactVm
        /// </summary>
        /// <param name="contactVm">The contact to create</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(ContactViewModel contactVm)
        {
            if (!ModelState.IsValid)
            {
                contactVm.PartnerNumberSelection = GetPartnerSelection();
                return View(contactVm);
            }

            _contacts.Add(contactVm.Map<Contact>());

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        /// <summary>
        /// Method will display the contact which needs to be updated
        /// </summary>
        /// <param name="id">Id of the contact to be updated</param>
        /// <returns></returns>
        [HttpGet]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {
            var contactInDb = await _contacts.GetAsync(id);

            if (contactInDb == null)
            {
                return View("List");
            }

            var contactVm = contactInDb.Map<ContactViewModel>();

            contactVm.PartnerNumberSelection = GetPartnerSelection();

            return View(contactVm);
        }

        /// <summary>
        /// Method will update a previously selected contact
        /// </summary>
        /// <param name="contactVm">Contact to be updated</param>
        /// <param name="id">Id of the updated contact</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, ContactViewModel contactVm)
        {
            if (!ModelState.IsValid)
            {
                return View(contactVm);
            }

            var contactInDb = await _contacts.GetAsync(id);

            if (contactInDb == null)
            {
                return View();
            }

            contactInDb = contactVm.Map<Contact>();

            _contacts.Add(contactInDb);

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        /// <summary>
        /// Returns a list of partners available to be linked to the contact
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetPartnerSelection()
        {
            var partners = _partners.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Number
                });

            return new SelectList(partners, "Value", "Text");
        }
    }
}
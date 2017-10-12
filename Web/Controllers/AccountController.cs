using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Accounts;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.ContactViewModels;

namespace Web.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountController : BaseController
    {
        private readonly IComplete _unitOfWork;
        private readonly IAccountRepository<Account> _accounts;
        private readonly IPartnerRepository<Partner> _partners;

        public AccountController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _accounts = unitOfWork.Accounts;
            _partners = unitOfWork.Partners;
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

        [Route("create")]
        public ActionResult Open()
        {
            var partnerNumberSelection = new AccountViewModel
            {
                PartnerNumberSelection = GetPartnerSelection()
            };

            return View(partnerNumberSelection);
        }

        [HttpPost, Route("create")]
        public async Task<ActionResult> Open(AccountViewModel accountVm)
        {
            if (!ModelState.IsValid)
            {
                return View(accountVm);
            }

            var account = new Account();
            var partner = await _partners.GetAsync(accountVm.SelectedPartnerId);

            var validationResult = account.OpenNewAccount(accountVm.Name, accountVm.Number, partner);

            // TODO: Add validation message display for complex validation
            if (validationResult.Any())
            {
                return View();
            }

            _accounts.Add(account);

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        /// <summary>
        /// Returns a list of partners available to be linked to the contact
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetPartnerSelection()
        {
            var partnerSelection = _partners.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Number
                });

            return new SelectList(partnerSelection, "Value", "Text");
        }
    }
}
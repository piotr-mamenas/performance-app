using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Accounts;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Core.Validation;
using Infrastructure.Extensions;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.AccountViewModels;

namespace Web.Controllers
{
    [RoutePrefix("accounts")]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPartnerRepository _partnerRepository;

        public AccountController(IUnitOfWork unitOfWork, 
            IPartnerRepository partnerRepository,
            IAccountRepository accountRepository,
            ILogger logger)
            : base(logger, unitOfWork)
        {
            _accountRepository = accountRepository;
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
            var partnerNumberSelection = new AccountViewModel
            {
                PartnerNumberSelection = await GetPartnerSelection()
            };

            return View(partnerNumberSelection);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(AccountViewModel accountVm)
        {
            if (!ModelState.IsValid)
            {
                return View(accountVm);
            }
            
            var partner = await _partnerRepository.GetAsync(accountVm.SelectedPartnerId);
            
            if (partner == null)
            {
                return View(accountVm);
            }
            
            var account = Account.Build(accountVm.Name, accountVm.Number, partner.Id);
            _accountRepository.Add(account);

            await UnitOfWork.CompleteAsync();

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
            var accountInDb = await _accountRepository.GetAsync(id);

            if (accountInDb == null)
            {
                return View("List");
            }

            var accountVm = accountInDb.Map<AccountViewModel>();

            accountVm.PartnerNumberSelection = await GetPartnerSelection();

            return View(accountVm);
        }

        /// <summary>
        /// Method will update a previously selected contact
        /// </summary>
        /// <param name="id">Id of the updated contact</param>
        /// <param name="accountVm">Account to be updated</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, AccountViewModel accountVm)
        {
            if (!ModelState.IsValid)
            {
                return View(accountVm);
            }

            var accountInDb = await _accountRepository.GetAsync(id);

            if (accountInDb == null)
            {
                return View();
            }
            
            var updatedAccount = accountVm.Map<Account,AccountViewModel>();
            updatedAccount.ClosedDate = null;
            updatedAccount.OpenedDate = accountInDb.OpenedDate;

            var validationResult = updatedAccount.Validate();
            _accountRepository.Add(updatedAccount);

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
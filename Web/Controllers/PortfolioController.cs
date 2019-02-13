using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.PortfolioViewModels;

namespace Web.Controllers
{
    [RoutePrefix("portfolios")]
    [Authorize]
    public class PortfolioController : BaseController
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioController(IUnitOfWork unitOfWork, 
            IPortfolioRepository portfolioRepository,
            ILogger logger)
            : base(logger, unitOfWork)
        {
            _portfolioRepository = portfolioRepository;
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

        [Route("returns")]
        public ActionResult Returns()
        {
            return View();
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            var portfolioInDb = await _portfolioRepository.SingleOrDefaultAsync(p => p.Id == id);

            if (portfolioInDb == null)
            {
                return View("List");
            }

            return View(portfolioInDb.Map<PortfolioDetailsViewModel>());
        }

        [HttpGet]
        [Route("create")]
        public async Task<ActionResult> Create()
        {
            var portfolioVm = new NewPortfolioViewModel
            {
                AccountSelection = await GetAccountSelection()
            };
            return View(portfolioVm);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(NewPortfolioViewModel portfolioVm)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioVm);
            }

            _portfolioRepository.Add(portfolioVm.Map<Portfolio>());

            await UnitOfWork.CompleteAsync();

            return View("List");
        }

        private async Task<IEnumerable<SelectListItem>> GetAccountSelection()
        {
            var accounts = await _portfolioRepository.GetAllPortfoliosWithDetailsAsync();

            if (accounts != null)
            {
                var selectList = accounts.Select(p => new SelectListItem
                {
                    Value = p.AccountId.ToString(),
                    Text = p.Account.Number
                });
                return new SelectList(selectList, "Value", "Text");
            }
            return new SelectList(null,"Value","Text");
        }
    }
}
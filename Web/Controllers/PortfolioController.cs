using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.PortfolioViewModels;

namespace Web.Controllers
{
    [RoutePrefix("portfolios")]
    [Authorize]
    public class PortfolioController : BaseController
    {
        private readonly IPortfolioRepository _portfolios;
        private readonly IComplete _unitOfWork;

        public PortfolioController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _portfolios = unitOfWork.Portfolios;
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
            var portfolioInDb = await _portfolios.SingleOrDefaultAsync(p => p.Id == id);

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

            _portfolios.Add(portfolioVm.Map<Portfolio>());

            await _unitOfWork.CompleteAsync();

            return View("List");
        }

        private async Task<IEnumerable<SelectListItem>> GetAccountSelection()
        {
            var accounts = await _portfolios.GetAllPortfoliosWithDetailsAsync();

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
using System.Data.Entity;
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
        private readonly IPortfolioRepository<Portfolio> _portfolios;
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

        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            var portfolioInDb = await _portfolios.GetAll()
                .Include(p => p.Account)
                .Include(p => p.Account.Partner)
                .SingleAsync(p => p.Id == id);

            if (portfolioInDb == null)
            {
                return View("List");
            }

            return View(portfolioInDb.Map<PortfolioDetailsViewModel>());
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
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
    }
}
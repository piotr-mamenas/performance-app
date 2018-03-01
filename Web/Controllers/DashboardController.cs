using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Identity;
using Core.Domain.TileWidgets;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Microsoft.AspNet.Identity;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.DashboardViewModels;

namespace Web.Controllers
{
    [RoutePrefix("dashboard")]
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IComplete _unitOfWork;
        private readonly ITileWidgetRepository<TileWidget> _widgetRepository;
        private readonly UserManager<User> _userManager;

        public DashboardController(ILogger logger, IUnitOfWork unitOfWork, UserManager<User> userManager)
            : base(logger)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _widgetRepository = unitOfWork.TileWidgets;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            var user = _userManager.FindByName(User.Identity.Name);

            var userWidgets = await _widgetRepository.GetUserWidgets(user.Id);
            var dashboardViewModel = new DashboardViewModel();

            foreach (var widget in userWidgets)
            {
                var widgetVm = widget.Map<DashboardWidgetViewModel>();

                dashboardViewModel.UserWidgets.Add(widgetVm);
            }

            return View(dashboardViewModel);
        }
    }
}
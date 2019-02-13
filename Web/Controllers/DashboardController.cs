using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.ViewModels.DashboardViewModels;

namespace Web.Controllers
{
    [Authorize]
    [RoutePrefix("dashboard")]
    public class DashboardController : BaseController
    {
        private readonly ITileWidgetRepository _widgetRepository;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        public DashboardController(ILogger logger, IUnitOfWork unitOfWork, ApplicationUserManager userManager)
            : base(logger)
        {
            _widgetRepository = unitOfWork.TileWidgets;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            var user = _userManager.FindByName(User.Identity.Name);

            var userWidgets = await _widgetRepository.GetUserWidgetsByUserGuidAsync(user.Id);
            var userBookmarks = await _widgetRepository.GetUserBookmarksByUserGuidAsync(user.Id);

            var dashboardViewModel = new DashboardViewModel();
            var widgetVms = userWidgets.Map<IEnumerable<DashboardWidgetViewModel>>();
            var bookmarkVms = userBookmarks.Map<IEnumerable<DashboardWidgetBookmarkViewModel>>();

            dashboardViewModel.UserWidgets.AddRange(widgetVms);
            dashboardViewModel.UserWidgetBookmarks.AddRange(bookmarkVms);

            return View(dashboardViewModel);
        }
    }
}
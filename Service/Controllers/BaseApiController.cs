using System.Web;
using System.Web.Http;
using Core.Domain.Identity;
using Core.Interfaces;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Helpers;

namespace Service.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly ISessionService _sessionService;
        private readonly ILogger _logger;
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseApiController(ILogger logger, IUnitOfWork unitOfWork, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _logger = logger;
            UnitOfWork = unitOfWork;
        }

        protected User CurrentUser
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get(ConfigurationHelper.SessionCookieName);
                return _sessionService.GetCurrentUserByAuthenticationTokenAsync(cookie?.Value).Result;
            }
        }
    }
}
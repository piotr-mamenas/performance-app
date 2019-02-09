using System.Web;
using System.Web.Http;
using Core.Domain.Identity;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Helpers;

namespace Service.Controllers
{
    [ApplicationAuthorize]
    public class BaseApiController : ApiController
    {
        private readonly ISessionService _sessionService;
        private readonly ILogger _logger;

        protected BaseApiController(ILogger logger, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _logger = logger;
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
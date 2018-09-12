using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Infrastructure;
using Infrastructure.Services;

namespace Service.Helpers
{
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ICollection<string> _userRoles;
        private readonly ISessionService _sessionService;

        public ApplicationAuthorizeAttribute(params string[] additionalRoles)
        {
            _userRoles = new List<string>();
            _sessionService = new SessionService(ApplicationDbContext.Create());

            foreach (var role in additionalRoles)
            {
                _userRoles.Add(role);
            }
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            var cookie = filterContext.Request
                .Headers
                .GetCookies(ConfigurationHelper.SessionCookieName)
                .FirstOrDefault();
            
            var tokenUser = _sessionService.GetCurrentUserByAuthenticationTokenAsync(cookie[ConfigurationHelper.SessionCookieName].Value).Result;
            if (tokenUser == null)
            {
                filterContext.Response.StatusCode = HttpStatusCode.Unauthorized;
            }

            var isAllowedAccess = !_userRoles.Any();

            foreach (var role in tokenUser.Roles)
            {
                if (_userRoles.Contains(role.RoleId))
                {
                    isAllowedAccess = true;
                }
            }

            if (!isAllowedAccess)
            {
                filterContext.Response.StatusCode = HttpStatusCode.Unauthorized; //TODO: solve exception
            }
        }
    }
}

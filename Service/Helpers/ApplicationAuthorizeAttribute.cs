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
        private readonly ISessionService _authService;

        public ApplicationAuthorizeAttribute(params string[] additionalRoles)
        {
            _userRoles = new List<string>();
            _authService = new SessionService(ApplicationDbContext.Create());

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
            
            var tokenUser = _authService.GetCurrentUserByAuthenticationTokenAsync(cookie[ConfigurationHelper.SessionCookieName].Value).Result;
            if (tokenUser == null)
            {
                filterContext.Response.StatusCode = HttpStatusCode.Unauthorized;
            }

            var isAllowedAccess = false;
            foreach (var role in tokenUser.Roles)
            {
                if (_userRoles.Contains(role.RoleId))
                {
                    isAllowedAccess = true;
                }
            }

            if (!isAllowedAccess)
            {
                filterContext.Response.StatusCode = HttpStatusCode.Unauthorized;
            }
        }
    }
}

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
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ICollection<string> _userRoles;
        private readonly IAuthenticationService _authService;

        public ApplicationAuthorizeAttribute(params string[] additionalRoles)
        {
            _userRoles = new List<string>();
            _authService = new AuthenticationService(ApplicationDbContext.Create());

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
            
            var isTokenValid = _authService.IsTokenValidAsync(cookie[ConfigurationHelper.SessionCookieName].Value).Result;

            if (!isTokenValid)
            {
                filterContext.Response.StatusCode = HttpStatusCode.Unauthorized;
            }
        }
    }
}

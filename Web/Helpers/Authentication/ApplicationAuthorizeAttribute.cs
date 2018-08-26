using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Infrastructure;
using Infrastructure.Services;

namespace Web.Helpers.Authentication
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

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/auth/login", true);
            }
            else
            {
                foreach (var role in _userRoles)
                {
                    if (!user.IsInRole(role))
                    {
                        filterContext.HttpContext.Response.Redirect("/auth/login", true);
                    }
                }

                var cookie = filterContext.HttpContext.Request.Cookies.Get(ConfigurationHelper.SessionCookieName);
                var isTokenValid = _authService.IsTokenValidAsync(cookie?.Value).Result;

                if (!isTokenValid)
                {
                    filterContext.HttpContext.Response.Redirect("/auth/login", true);
                }
            }
        }
    }
}

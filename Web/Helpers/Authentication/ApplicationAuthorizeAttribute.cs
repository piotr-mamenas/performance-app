using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Web.Helpers.Authentication
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ICollection<string> _userRoles;
        
        public ApplicationAuthorizeAttribute(params string[] additionalRoles)
        {
            _userRoles = new List<string>();

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
            }
        }
    }
}

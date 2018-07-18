using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Core.Domain.Identity;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Service.Startup))]

namespace Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "DefaultCookie",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
                    OnApplyRedirect = ApplyRedirect
                }
            });
        }

        public static void ApplyRedirect(CookieApplyRedirectContext context)
        {
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out Uri absoluteUri))
            {
                var path = PathString.FromUriComponent(absoluteUri);

                if (path == context.OwinContext.Request.PathBase + context.Options.LoginPath)
                {
                    context.RedirectUri = "/Account/Login" + 
                        new QueryString(context.Options.ReturnUrlParameter, context.Request.Uri.AbsoluteUri);
                }
            }
            context.Response.Redirect(context.RedirectUri);
        }
    }
}

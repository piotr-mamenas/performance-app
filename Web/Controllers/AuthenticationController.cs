using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Domain.Identity;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.IdentityViewModels;

namespace Web.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        // TODO: To consider moving the beggining file to config
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public AuthenticationController(ILogger logger)
            : base(logger)
        {
        }

        public AuthenticationController(ILogger logger, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
            : base(logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginVm, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var result = await SignInManager.PasswordSignInAsync(loginVm.Username, loginVm.Password, loginVm.IsPersistent, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToRoute(returnUrl);

                case SignInStatus.LockedOut:
                    ModelState.AddModelError("", "Account locked out, please contact administrator");
                    return View(loginVm);

                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Username or password is incorrect");
                    return View(loginVm);

                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(loginVm);
            }
        }
    }
}
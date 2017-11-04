using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.IdentityViewModels;

namespace Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
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
        /// <returns></returns>
        [Route("")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("")]
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
                    return RedirectToAction("Login", loginVm);

                case SignInStatus.Failure:
                    return RedirectToAction("Login", loginVm);

                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return RedirectToAction("Login", loginVm);
            }
        }
    }
}
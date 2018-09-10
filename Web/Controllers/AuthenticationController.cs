using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Extensions.Logging;
using Web.Helpers;
using Web.Presentation.ViewModels.IdentityViewModels;

namespace Web.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private readonly ISessionService _sessionService;
        private readonly ILogger _logger;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        public AuthenticationController(ILogger logger, ISessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        public AuthenticationController(ILogger logger, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _logger = logger;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginVm"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
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
                    if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                    {
                        var authenticationToken = await _sessionService.StartSession(loginVm.Username);
                        Response.Cookies.Add(new HttpCookie(ConfigurationHelper.SessionCookieName,authenticationToken));
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Partner");

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

        /// <summary>
        /// Logs out the currently signed in User
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }

        [Route("changepassword")]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Route("changepassword")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await UserManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return View(viewModel);
            }

            user.PasswordHash = UserManager.PasswordHasher.HashPassword(viewModel.Password);
            var result = await UserManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new ApplicationException();
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
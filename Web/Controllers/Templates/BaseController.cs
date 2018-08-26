using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Helpers.Authentication;

namespace Web.Controllers.Templates
{
    [ApplicationAuthorize]
    public abstract class BaseController : Controller
    {
        protected readonly ILogger Logger;

        protected BaseController(ILogger logger)
        {
            Logger = logger;
        }
    }
}
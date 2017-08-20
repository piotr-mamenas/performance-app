using System.Web.Mvc;
using Ninject.Extensions.Logging;

namespace Web.Controllers.Templates
{
    public abstract class BaseController : Controller
    {
        protected readonly ILogger Logger;

        protected BaseController(ILogger logger)
        {
            Logger = logger;
        }
    }
}
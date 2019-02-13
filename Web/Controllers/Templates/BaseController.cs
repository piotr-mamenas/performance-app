using System.Web.Mvc;
using Core.Interfaces;
using Ninject.Extensions.Logging;
using Web.Helpers.Authentication;

namespace Web.Controllers.Templates
{
    [ApplicationAuthorize]
    public abstract class BaseController : Controller
    {
        protected readonly ILogger Logger;
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseController(ILogger logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }
    }
}
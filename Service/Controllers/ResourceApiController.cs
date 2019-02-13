using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Core.Domain.TileWidgets;
using Core.Interfaces;
using Infrastructure.Services;
using Ninject.Extensions.Logging;

namespace Service.Controllers
{
    [RoutePrefix("api/resources")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResourceApiController : BaseApiController
    {
        public ResourceApiController(ILogger logger,
            IUnitOfWork unitOfWork,
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
        }

        [HttpGet, Route("icons")]
        public ICollection<string> GetAvailableIconNames()
        {
            ICollection<string> availableIcons = new List<string>
            {
                FontAwesomeIcon.StickyNote,
                FontAwesomeIcon.Cogs,
                FontAwesomeIcon.LargeBook,
                FontAwesomeIcon.LargeBriefCase,
                FontAwesomeIcon.LargeLink
            };
            return availableIcons;
        }

        [HttpGet, Route("largeicons")]
        public ICollection<string> GetAvailableLargeIconNames()
        {
            ICollection<string> availableIcons = new List<string>
            {
                FontAwesomeIcon.LargeBriefCase,
                FontAwesomeIcon.LargeLink,
                FontAwesomeIcon.LargeBook
            };
            return availableIcons;
        }
    }
}

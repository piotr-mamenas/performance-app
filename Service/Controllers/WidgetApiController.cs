using Core.Domain.TileWidgets;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Service.Dtos.Widget;
using Service.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Infrastructure.Services;
using Ninject.Extensions.Logging;

namespace Service.Controllers
{
    [RoutePrefix("api/widget")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WidgetApiController : BaseApiController
    {
        private readonly ITileWidgetRepository _widgetRepository;

        public WidgetApiController(IUnitOfWork unitOfWork, 
            ITileWidgetRepository tileWidgetRepository, 
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            _widgetRepository = tileWidgetRepository;
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(CreateWidgetDto createWidgetDto)
        {
            var newWidget = TileWidget.Build(CurrentUser.Id, createWidgetDto.Name, createWidgetDto.Icon, createWidgetDto.BookmarkId);
            _widgetRepository.Add(newWidget);

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + newWidget.Id), newWidget);
        }
    }
}

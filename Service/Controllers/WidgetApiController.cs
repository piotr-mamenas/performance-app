using Core.Domain.TileWidgets;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Service.Dtos.Widget;
using Service.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [RoutePrefix("api/widget")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WidgetApiController : BaseApiController
    {
        private readonly ITileWidgetRepository _repository;
        private readonly IComplete _unitOfWork;

        public WidgetApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.TileWidgets;
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(CreateWidgetDto createWidgetDto)
        {
            var newWidget = TileWidget.Build(CurrentUser.Id, createWidgetDto.Name, createWidgetDto.Name, createWidgetDto.Url);
            _repository.Add(newWidget);

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + newWidget.Id), newWidget);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.TileWidgets;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Ninject.Activation;
using Service.Dtos.Widget;

namespace Service.Controllers
{
    public class WidgetApiController : BaseApiController
    {
        private readonly ITileWidgetRepository<TileWidget> _repository;
        private readonly IComplete _unitOfWork;

        public WidgetApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.TileWidgets;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(CreateWidgetDto createWidgetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newWidget = TileWidget.Build(CurrentUser.Id, createWidgetDto.Name, createWidgetDto.Name, createWidgetDto.Url);
            _repository.Add(newWidget);

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + newWidget.Id), newWidget);
        }
    }
}

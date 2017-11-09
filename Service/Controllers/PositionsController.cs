using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories.Portfolios;
using Infrastructure.AutoMapper;
using Service.Dtos.Portfolio;

namespace Service.Controllers
{
    [RoutePrefix("api/positions")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PositionsController : ApiController
    {
        private readonly IPortfolioAssetPositionRepository<PortfolioAssetPosition> _repository;
        private readonly IComplete _unitOfWork;

        public PositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Positions;
        }

        [ResponseType(typeof(ICollection<PositionDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var positions = await _repository.GetAll()
                .Include(p => p.Asset)
                .Include(p => p.Currency)
                .ToListAsync();

            if (positions == null)
            {
                return NotFound();
            }
            return Ok(positions.Map<ICollection<PositionDto>>());
        }

        [ResponseType(typeof(PositionDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var position = await _repository.GetAsync(id);

            if (position == null)
            {
                return NotFound();
            }
            return Ok(position.Map<PositionDto>());
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, PositionDto position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var positionInDb = await _repository.GetAsync(id);

            if (positionInDb == null)
            {
                return NotFound();
            }

            _repository.Add(position.Map<PortfolioAssetPosition>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(PositionDto position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(position.Map<PortfolioAssetPosition>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + position.Id), position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var position = await _repository.GetAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            _repository.Remove(position);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

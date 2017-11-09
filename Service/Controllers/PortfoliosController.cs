using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Portfolio;
using Infrastructure.AutoMapper;
using Service.Dtos;
using Service.Dtos.Portfolio;

namespace Service.Controllers
{
    [RoutePrefix("api/portfolios")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PortfoliosController : ApiController
    {
        private readonly IPortfolioRepository<Portfolio> _repository;
        private readonly IComplete _unitOfWork;

        public PortfoliosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Portfolios;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<PortfolioDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var portfolios = await _repository.GetAll().ToListAsync();

            if (portfolios == null)
            {
                return NotFound();
            }
            return Ok(portfolios.Map<ICollection<PortfolioDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(PortfolioDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var portfolio = await _repository.GetAsync(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio.Map<PortfolioDto>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="portfolio"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, PortfolioDto portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var portfolioInDb = await _repository.GetAsync(id);

            if (portfolioInDb == null)
            {
                return NotFound();
            }

            _repository.Add(portfolio.Map<Portfolio>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(PortfolioDto portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(portfolio.Map<Portfolio>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + portfolio.Id), portfolio);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var portfolio = await _repository.GetAsync(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            _repository.Remove(portfolio);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Service.Dtos.Portfolio;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/portfolios")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PortfolioApiController : BaseApiController
    {
        private readonly IPortfolioRepository _repository;
        private readonly IComplete _unitOfWork;

        public PortfolioApiController(IUnitOfWork unitOfWork)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new AccountContractResolver();

            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Portfolios;
        }

        [ResponseType(typeof(ICollection<PortfolioDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var portfolios = await _repository.GetAllPortfoliosWithDetailsAsync();

            if (portfolios == null)
            {
                return NotFound();
            }
            return Ok(portfolios.Map<ICollection<PortfolioDto>>());
        }

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

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, PortfolioDto portfolio)
        {
            var portfolioInDb = await _repository.GetAsync(id);

            if (portfolioInDb == null)
            {
                return NotFound();
            }

            _repository.Add(portfolio.Map<Portfolio>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(PortfolioDto portfolio)
        {
            _repository.Add(portfolio.Map<Portfolio>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + portfolio.Id), portfolio);
        }

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
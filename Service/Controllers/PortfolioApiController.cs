using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Portfolios;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Repositories.Business;
using Infrastructure.Serialization.JsonContractResolvers;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Portfolio;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/portfolios")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PortfolioApiController : BaseApiController
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioApiController(IUnitOfWork unitOfWork, 
            IPortfolioRepository portfolioRepository, 
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new AccountContractResolver();

            _portfolioRepository = portfolioRepository;
        }

        [ResponseType(typeof(ICollection<PortfolioDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var portfolios = await _portfolioRepository.GetAllPortfoliosWithDetailsAsync();

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
            var portfolio = await _portfolioRepository.GetAsync(id);

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
            var portfolioInDb = await _portfolioRepository.GetAsync(id);

            if (portfolioInDb == null)
            {
                return NotFound();
            }

            _portfolioRepository.Add(portfolio.Map<Portfolio>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(PortfolioDto portfolio)
        {
            _portfolioRepository.Add(portfolio.Map<Portfolio>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + portfolio.Id), portfolio);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var portfolio = await _portfolioRepository.GetAsync(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            _portfolioRepository.Remove(portfolio);

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
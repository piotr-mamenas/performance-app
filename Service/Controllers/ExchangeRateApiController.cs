using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.ExchangeRates;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.BaseData;
using Service.Dtos.ExchangeRate;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/exchangerates")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExchangeRateApiController : BaseApiController
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateApiController(IUnitOfWork unitOfWork, 
            IExchangeRateRepository exchangeRateRepository,
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        [HttpGet, Route("")]
        [ResponseType(typeof(ICollection<ExchangeRateDto>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var exchangeRates = await _exchangeRateRepository.GetExchangeRatesWithCurrenciesAsync();

            if (exchangeRates == null)
            {
                return NotFound();
            }
            return Ok(exchangeRates.Map<ICollection<ExchangeRateDto>>());
        }

        [HttpGet, Route("{id}")]
        [ResponseType(typeof(ExchangeRate))]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var exchangeRate = await _exchangeRateRepository.GetAsync(id);

            if (exchangeRate == null)
            {
                return NotFound();
            }
            return Ok(exchangeRate.Map<CurrencyDto>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, ExchangeRateDto exchangeRate)
        {
            var exchangeRateInDb = await _exchangeRateRepository.GetAsync(id);

            if (exchangeRateInDb == null)
            {
                return NotFound();
            }

            _exchangeRateRepository.Add(exchangeRate.Map<ExchangeRate>());
            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> Create(ExchangeRateDto exchangeRate)
        {
            _exchangeRateRepository.Add(exchangeRate.Map<ExchangeRate>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + exchangeRate.Id), exchangeRate);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var exchangeRateInDb = await _exchangeRateRepository.GetAsync(id);

            if (exchangeRateInDb == null)
            {
                return NotFound();
            }

            _exchangeRateRepository.Remove(exchangeRateInDb);

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

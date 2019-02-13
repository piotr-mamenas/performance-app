using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Currencies;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;
using Infrastructure.Extensions;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.BaseData;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/currencies")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CurrencyApiController : BaseApiController
    {
        private readonly ICurrencyRepository _repository;
        private readonly IComplete _unitOfWork;

        public CurrencyApiController(IUnitOfWork unitOfWork, ILogger logger, ISessionService sessionService)
            : base(logger, sessionService)
        {
            _repository = unitOfWork.Currencies;
            _unitOfWork = (IComplete)unitOfWork;
        }

        [HttpGet, Route("")]
        [ResponseType(typeof(ICollection<CurrencyDto>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var currencies = await _repository.GetAllCurrenciesAsync();

            if (currencies == null)
            {
                return NotFound();
            }
            return Ok(currencies.Map<ICollection<CurrencyDto>>());
        }

        [HttpGet, Route("{id}")]
        [ResponseType(typeof(CurrencyDto))]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var currency = await _repository.GetAsync(id);

            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency.Map<CurrencyDto>());
        }
        
        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, CurrencyDto currency)
        {
            var currencyInDb = await _repository.GetAsync(id);

            if (currencyInDb == null)
            {
                return NotFound();
            }

            _repository.Add(currency.Map<Currency>());
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> Create(CurrencyDto currency)
        {
            _repository.Add(currency.Map<Currency>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + currency.Id), currency);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var currencyInDb = await _repository.GetAsync(id);

            if (currencyInDb == null)
            {
                return NotFound();
            }

            _repository.Remove(currencyInDb);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

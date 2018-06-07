using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.ExchangeRates;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Service.Dtos.BaseData;
using Service.Dtos.ExchangeRate;

namespace Service.Controllers
{
    [RoutePrefix("api/exchangerates")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExchangeRateApiController : BaseApiController
    {
        private readonly IExchangeRateRepository<ExchangeRate> _repository;
        private readonly IComplete _unitOfWork;

        public ExchangeRateApiController(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.ExchangeRates;
            _unitOfWork = (IComplete)unitOfWork;
        }

        [HttpGet, Route("")]
        [ResponseType(typeof(ICollection<ExchangeRateDto>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var exchangeRates = await _repository.GetAll()
                .Include(er => er.BaseCurrency)
                .Include(er => er.TargetCurrency)
                .ToListAsync();

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
            var exchangeRate = await _repository.GetAsync(id);

            if (exchangeRate == null)
            {
                return NotFound();
            }
            return Ok(exchangeRate.Map<CurrencyDto>());
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, ExchangeRateDto exchangeRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var exchangeRateInDb = await _repository.GetAsync(id);

            if (exchangeRateInDb == null)
            {
                return NotFound();
            }

            _repository.Add(exchangeRate.Map<ExchangeRate>());
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(ExchangeRateDto exchangeRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(exchangeRate.Map<ExchangeRate>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + exchangeRate.Id), exchangeRate);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var exchangeRateInDb = await _repository.GetAsync(id);

            if (exchangeRateInDb == null)
            {
                return NotFound();
            }

            _repository.Remove(exchangeRateInDb);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

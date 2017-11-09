using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.BaseData.Currencies;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;
using Infrastructure.AutoMapper;
using Service.Dtos.BaseData;

namespace Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/currencies")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CurrenciesController : ApiController
    {
        private readonly ICurrencyRepository<Currency> _repository;
        private readonly IComplete _unitOfWork;

        public CurrenciesController(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Currencies;
            _unitOfWork = (IComplete)unitOfWork;
        }

        /// <summary>
        /// Get All Currencies
        /// </summary>
        /// <returns>Currencies Collection JSON by default</returns>
        [HttpGet, Route("")]
        [ResponseType(typeof(ICollection<CurrencyDto>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var currencies = await _repository.GetAll().ToListAsync();

            if (currencies == null)
            {
                return NotFound();
            }
            return Ok(currencies.Map<ICollection<CurrencyDto>>());
        }

        /// <summary>
        /// Get Single Currency
        /// </summary>
        /// <param name="id">Id of the currency in the Database</param>
        /// <returns>Currency JSON by default</returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, CurrencyDto currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currencyInDb = await _repository.GetAsync(id);

            if (currencyInDb == null)
            {
                return NotFound();
            }

            _repository.Add(currency.Map<Currency>());
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(CurrencyDto currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(currency.Map<Currency>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + currency.Id), currency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

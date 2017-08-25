using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Domain.Countries;
using Core.Dtos;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Extensions;

namespace Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/countries")]
    public class CountriesController : ApiController
    {
        private readonly IComplete _unitOfWork;
        private readonly ICountryRepository _repository;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Countries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<CountryDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var countries = await _repository.GetAll().ToListAsync();

            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries.Map<ICollection<CountryDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(CountryDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var country = await _repository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country.Map<CountryDto>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, CountryDto country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var countryInDb = await _repository.GetAsync(id);

            if (countryInDb == null)
            {
                return NotFound();
            }

            _repository.Add(country.Map<Country>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(CountryDto country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(country.Map<Country>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + country.Id), country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var country = await _repository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _repository.Remove(country);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

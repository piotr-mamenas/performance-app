using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Countries;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;
using Infrastructure.AutoMapper;
using Service.Dtos.BaseData;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/countries")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CountryApiController : BaseApiController
    {
        private readonly IComplete _unitOfWork;
        private readonly ICountryRepository<Country> _repository;

        public CountryApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Countries;
        }

        [ResponseType(typeof(ICollection<CountryDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var countries = await _repository.GetAllCountriesAsync();

            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries.Map<ICollection<CountryDto>>());
        }

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

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, CountryDto country)
        {
            var countryInDb = await _repository.GetAsync(id);

            if (countryInDb == null)
            {
                return NotFound();
            }

            _repository.Add(country.Map<Country>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(CountryDto country)
        {
            _repository.Add(country.Map<Country>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + country.Id), country);
        }

        [HttpDelete, Route("{id}/delete")]
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

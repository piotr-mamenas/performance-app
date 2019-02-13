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
using Infrastructure.Extensions;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.BaseData;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/countries")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CountryApiController : BaseApiController
    {
        private readonly ICountryRepository _countryRepository;

        public CountryApiController(IUnitOfWork unitOfWork, 
            ICountryRepository countryRepository,
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            _countryRepository = countryRepository;
        }

        [ResponseType(typeof(ICollection<CountryDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();

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
            var country = await _countryRepository.GetAsync(id);

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
            var countryInDb = await _countryRepository.GetAsync(id);

            if (countryInDb == null)
            {
                return NotFound();
            }

            _countryRepository.Add(country.Map<Country>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(CountryDto country)
        {
            _countryRepository.Add(country.Map<Country>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + country.Id), country);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var country = await _countryRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _countryRepository.Remove(country);

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

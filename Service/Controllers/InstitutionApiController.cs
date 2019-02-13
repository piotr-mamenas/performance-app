using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Institutions;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Institution;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/institutions")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InstitutionApiController : BaseApiController
    {
        private readonly IInstitutionRepository _institutionRepository;

        public InstitutionApiController(IUnitOfWork unitOfWork, 
            IInstitutionRepository institutionRepository,
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            _institutionRepository = institutionRepository;
        }

        [ResponseType(typeof(ICollection<InstitutionDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var institutions = await _institutionRepository.GetAllInstitutionsAsync();

            if (institutions == null)
            {
                return NotFound();
            }

            return Ok(institutions.Map<ICollection<Institution>>());
        }

        [ResponseType(typeof(InstitutionDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var institution = await _institutionRepository.GetAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return Ok(institution.Map<InstitutionDto>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, InstitutionDto institution)
        {
            var institutionInDb = await _institutionRepository.GetAsync(id);

            if (institutionInDb == null)
            {
                return NotFound();
            }

            _institutionRepository.Add(institution.Map<Institution>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(InstitutionDto institution)
        {
            _institutionRepository.Add(institution.Map<Institution>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + institution.Id), institution);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var institution = _institutionRepository.GetAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            _institutionRepository.Remove(institution.Map<Institution>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

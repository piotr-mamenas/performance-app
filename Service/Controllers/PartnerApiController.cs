using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Service.Dtos.Partner;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/partners")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PartnerApiController : BaseApiController
    {
        private readonly IComplete _unitOfWork;
        private readonly IPartnerRepository _partnersRepository;

        public PartnerApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _partnersRepository = unitOfWork.Partners;
        }

        [ResponseType(typeof(ICollection<PartnerDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var partners = await _partnersRepository.GetAllPartnersWithTypesAsync();

            if (partners == null)
            {
                return NotFound();
            }
            return Ok(partners.Map<ICollection<PartnerDto>>());
        }

        [ResponseType(typeof(PartnerDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var partner = await _partnersRepository.GetAsync(id);

            if (partner == null)
            {
                return NotFound();    
            }

            return Ok(partner.Map<PartnerDto>());
        }

        [ResponseType(typeof(PartnerDto))]
        [HttpGet, Route("accounts/{id}")]
        public async Task<IHttpActionResult> GetByAccountAsync(int id)
        {
            var partners = await _partnersRepository.GetAccountPartnersAsync(id);

            if (partners == null)
            {
                return NotFound();
            }

            return Ok(partners.Map<ICollection<PartnerDto>>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, PartnerDto partner)
        {
            var partnerInDb = await _partnersRepository.GetAsync(id);

            if (partnerInDb == null)
            {
                return NotFound();
            }

            _partnersRepository.Add(partner.Map<Partner>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(PartnerDto partner)
        {
            _partnersRepository.Add(partner.Map<Partner>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + partner.Id), partner);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var partner = await _partnersRepository.GetByIdWithAccountsAndContactsAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            var deletionError = partner.ValidateDelete();

            if (deletionError != null)
            {
                var httpError = new HttpError(deletionError);

                var response = Request.CreateResponse(HttpStatusCode.MethodNotAllowed, httpError);
                return ResponseMessage(response);
            }

            _partnersRepository.Remove(partner);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

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
using Core.Domain.Accounts;
using Core.Domain.Contacts;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Service.Dtos.Partner;

namespace Service.Controllers
{
    [RoutePrefix("api/partners")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PartnerApiController : ApiController
    {
        private readonly IComplete _unitOfWork;
        private readonly IPartnerRepository<Partner> _partnersRepository;

        public PartnerApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _partnersRepository = unitOfWork.Partners;
        }

        [ResponseType(typeof(ICollection<PartnerDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var partners = await _partnersRepository.GetAll()
                .Include(p => p.Type)
                .ToListAsync();

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
            var partners = await _partnersRepository.GetAll()
                .Where(a => a.Accounts.Any(p => p.Id == id))
                .ToListAsync();

            if (partners == null)
            {
                return NotFound();
            }

            return Ok(partners.Map<ICollection<PartnerDto>>());
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, PartnerDto partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> CreateAsync(PartnerDto partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _partnersRepository.Add(partner.Map<Partner>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + partner.Id), partner);
        }

        [HttpDelete, HttpGet, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var partner = await _partnersRepository.GetAll()
                .Where(p => p.Id == id)
                .Include(p => p.Accounts)
                .Include(p => p.Contacts)
                .SingleOrDefaultAsync();

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

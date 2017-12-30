using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
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
        private readonly IPartnerRepository<Partner> _repository;

        public PartnerApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _repository = unitOfWork.Partners;
        }

        [ResponseType(typeof(ICollection<PartnerDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var partners = await _repository.GetAll()
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
            var partner = await _repository.GetAsync(id);

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
            var partners = await _repository.GetAll()
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

            var partnerInDb = await _repository.GetAsync(id);

            if (partnerInDb == null)
            {
                return NotFound();
            }

            _repository.Add(partner.Map<Partner>());

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

            _repository.Add(partner.Map<Partner>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + partner.Id), partner);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var partner = await _repository.GetAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            _repository.Remove(partner);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

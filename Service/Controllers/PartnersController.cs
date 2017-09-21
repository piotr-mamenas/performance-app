using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.AutoMapper;
using Service.Dtos;

namespace Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/partners")]
    public class PartnersController : ApiController
    {
        private readonly IComplete _unitOfWork;
        private readonly IPartnerRepository<Partner> _repository;

        public PartnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (IComplete) unitOfWork;
            _repository = unitOfWork.Partners;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<PartnerDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var partners = await _repository.GetAll().ToListAsync();

            if (partners == null)
            {
                return NotFound();
            }
            return Ok(partners.Map<ICollection<PartnerDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partner"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
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

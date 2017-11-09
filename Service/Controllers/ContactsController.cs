using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories.Partners;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Service.Dtos.Partner;

namespace Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/contacts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {
        private readonly IPartnerContactRepository<PartnerContact> _repository;
        private readonly IComplete _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new ContactContractResolver();

            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Contacts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ICollection<PartnerContactDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var contacts = await _repository.GetAll()
                .Include(p => p.Partner)
                .ToListAsync();

            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts.Map<ICollection<PartnerContactDto>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(PartnerContactDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var contact = await _repository.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact.Map<PartnerContactDto>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id, PartnerContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contactInDb = await _repository.GetAsync(id);

            if (contactInDb == null)
            {
                return NotFound();
            }
            
            _repository.Add(contact.Map<PartnerContact>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateAsync(PartnerContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(contact.Map<PartnerContact>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contact);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var contact = await _repository.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _repository.Remove(contact);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

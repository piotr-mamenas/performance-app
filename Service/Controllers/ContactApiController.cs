using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Contacts;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Service.Dtos.Contact;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/contacts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactApiController : BaseApiController
    {
        private readonly IContactRepository _repository;
        private readonly IComplete _unitOfWork;

        public ContactApiController(IUnitOfWork unitOfWork)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new ContactContractResolver();

            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Contacts;
        }

        [ResponseType(typeof(ICollection<ContactDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var contacts = await _repository.GetAllContactsWithPartnersAsync();

            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts.Map<ICollection<ContactDto>>());
        }

        [ResponseType(typeof(ContactDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var contact = await _repository.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact.Map<ContactDto>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, ContactDto contact)
        {
            var contactInDb = await _repository.GetAsync(id);

            if (contactInDb == null)
            {
                return NotFound();
            }
            
            _repository.Add(contact.Map<Contact>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(ContactDto contact)
        {
            _repository.Add(contact.Map<Contact>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contact);
        }

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

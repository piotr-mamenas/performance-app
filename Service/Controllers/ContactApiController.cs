using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Contacts;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Serialization.JsonContractResolvers;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Contact;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/contacts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactApiController : BaseApiController
    {
        private readonly IContactRepository _contactRepository;

        public ContactApiController(IUnitOfWork unitOfWork, 
            IContactRepository contactRepository,
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new ContactContractResolver();

            _contactRepository = contactRepository;
        }

        [ResponseType(typeof(ICollection<ContactDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var contacts = await _contactRepository.GetAllContactsWithPartnersAsync();

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
            var contact = await _contactRepository.GetAsync(id);

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
            var contactInDb = await _contactRepository.GetAsync(id);

            if (contactInDb == null)
            {
                return NotFound();
            }

            _contactRepository.Add(contact.Map<Contact>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(ContactDto contact)
        {
            _contactRepository.Add(contact.Map<Contact>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contact);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var contact = await _contactRepository.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactRepository.Remove(contact);

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

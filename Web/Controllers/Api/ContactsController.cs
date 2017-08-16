using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Domain.Contact;
using Core.Interfaces;

namespace Web.Controllers.Api
{
    //TODO: Switch return types to Dto's, current implementation only for testing unitofwork
    public class ContactsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ResponseType(typeof(BaseContact))]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, BaseContact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contactInDb = await _unitOfWork.Contacts.GetAsync(id);

            if (contactInDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Contacts.Add(contact);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}

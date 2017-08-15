using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Domain.Partner;
using Core.Interfaces;

namespace Web.Controllers.Api
{
    public class PartnersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseType(typeof(BasePartner))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var partner = await _unitOfWork.Partners.GetAsync(id);

            if (partner != null)
            {
                return Ok(partner);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, BasePartner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var partnerInDb = await _unitOfWork.Partners.SingleOrDefaultAsync(p => p.Id == id);

            if (partnerInDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Partners.Add(partner);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(BasePartner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.Partners.Add(partner);
            await _unitOfWork.CompleteAsync();
            return Created(new Uri(Request.RequestUri + "/" + partner.Id), partner);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var partner = await _unitOfWork.Partners.GetAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            _unitOfWork.Partners.Remove(partner);

            return Ok();
        }
    }
}

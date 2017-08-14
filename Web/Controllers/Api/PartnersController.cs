using System.Web.Http;
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
        public IHttpActionResult Get(int id)
        {
            var partner = _unitOfWork.Partners.Get(id);
            return Ok(partner);
        }
    }
}

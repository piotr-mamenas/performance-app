using System.Web.Http;

namespace PerformanceApp.Controllers.Api
{
    public class PartnersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }
    }
}

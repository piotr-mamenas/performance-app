using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Accounts;
using Core.Domain.TileWidgets;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Service.Dtos.Account;

namespace Service.Controllers
{
    [RoutePrefix("api/resources")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResourceApiController : ApiController
    {
        [HttpGet, Route("icons")]
        public ICollection<string> GetAvailableIconNames()
        {
            ICollection<string> availableIcons = new List<string>
            {
                FontAwesomeIcon.StickyNote,
                FontAwesomeIcon.Cogs,
                FontAwesomeIcon.LargeBook,
                FontAwesomeIcon.LargeBriefCase,
                FontAwesomeIcon.LargeLink
            };
            return availableIcons;
        }
    }
}

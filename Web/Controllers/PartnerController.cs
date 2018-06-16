using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;
using Web.Presentation.ViewModels.PartnerViewModels;

namespace Web.Controllers
{
    [Authorize]
    [RoutePrefix("partners")]
    public class PartnerController : BaseController
    {
        private readonly IPartnerRepository _partners;
        private readonly IComplete _unitOfWork;

        /// <summary>
        /// Default constructor with injected components
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public PartnerController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            _unitOfWork = (IComplete)unitOfWork;
            _partners = unitOfWork.Partners;
        }

        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// List all Partners
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        public ActionResult List()
        {
            return View();
        }
        
        /// <summary>
        /// Create new Partner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var partnerVm = new PartnerViewModel
            {
                PartnerTypeSelection = GetPartnerTypeSelection()
            };
            return View(partnerVm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partnerVm">The viewmodel for the partner to be created</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(PartnerViewModel partnerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(partnerVm);
            }
            
            _partners.Add(partnerVm.Map<Partner>());

            await _unitOfWork.CompleteAsync();

            return View("List");
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {
            var partnerInDb = await _partners.GetAsync(id);

            if (partnerInDb == null)
            {
                return View("List");
            }

            var partnerVm = partnerInDb.Map<PartnerViewModel>();
            partnerVm.PartnerTypeSelection = GetPartnerTypeSelection();

            return View(partnerVm);
        }

        /// <summary>
        /// Update the Partner 
        /// </summary>
        /// <param name="id">The Id of the partner to be updated</param>
        /// <param name="partnerVm">The viewmodel of the partner to be updated</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, PartnerViewModel partnerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(partnerVm);
            }

            var partnerInDb = await _partners.GetAsync(id);

            if (partnerInDb == null)
            {
                return View(partnerVm);
            }

            partnerInDb = partnerVm.Map<Partner>();

            _partners.Add(partnerInDb);

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("List");
        }

        /// <summary>
        /// Returns a list of partners available to be linked to the contact
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetPartnerTypeSelection()
        {
            var partnerTypes = _partners.GetTypesAsQueryable()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                });

            return new SelectList(partnerTypes, "Value", "Text");
        }
    }
}
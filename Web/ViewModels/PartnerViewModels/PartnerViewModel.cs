using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.PartnerViewModels
{
    public class PartnerViewModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Partner Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Partner Number")]
        public string Number { get; set; }

        [DisplayName("Partner Type")]
        public int SelectedPartnerTypeId { get; set; }

        public IEnumerable<SelectListItem> PartnerTypeSelection { get; set; }
    }
}

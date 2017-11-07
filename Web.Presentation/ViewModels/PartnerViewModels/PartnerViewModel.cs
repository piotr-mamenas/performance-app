using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Presentation.ViewModels.PartnerViewModels
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
    }
}

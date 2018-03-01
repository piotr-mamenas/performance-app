using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Presentation.ViewModels.DashboardViewModels
{
    public class DashboardWidgetViewModel
    {
        public string Icon { get; set; }

        [Required]
        [DisplayName("Widget Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Redirect to: ")]
        public string Url { get; set; }
    }
}

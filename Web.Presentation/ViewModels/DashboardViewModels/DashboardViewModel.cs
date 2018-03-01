using System.Collections.Generic;

namespace Web.Presentation.ViewModels.DashboardViewModels
{
    public class DashboardViewModel
    {
        public ICollection<DashboardWidgetViewModel> UserWidgets { get; set; }

        public DashboardViewModel()
        {
            UserWidgets = new List<DashboardWidgetViewModel>();
        }
    }
}

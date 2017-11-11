using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Web.Presentation.ViewModels.ReportViewModels
{
    public class GenerateReportViewModel
    {
        [DisplayName("Report Name")]
        public string Name { get; set; }

        [DisplayName("Date From")]
        public DateTime DateFrom { get; set; }

        [DisplayName("Date To")]
        public DateTime DateTo { get; set; }

        [DisplayName("Report Template")]
        public int SelectedReportTypeId { get; set; }

        public IEnumerable<SelectListItem> ReportTypeSelection { get; set; }
    }
}

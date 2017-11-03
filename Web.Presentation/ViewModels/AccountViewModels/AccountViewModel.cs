using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Presentation.ViewModels.AccountViewModels
{
    public class AccountViewModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Account Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Account Number")]
        public string Number { get; set; }

        [DisplayName("Related Partner")]
        public int SelectedPartnerId { get; set; }

        [Required]
        [DisplayName("Date Opened")]
        public DateTime OpenedDate { get; set; }
        
        [DisplayName("Date Closed")]
        public DateTime ClosedDate { get; set; }

        public IEnumerable<SelectListItem> PartnerNumberSelection { get; set; }
    }
}

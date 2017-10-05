using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Service.Dtos;

namespace Web.Presentation.ViewModels.ContactViewModels
{
    public class AccountViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Account Name")]
        public string Name { get; set; }

        [DisplayName("Account Number")]
        public string Number { get; set; }

        [DisplayName("Related Partner")]
        public int SelectedPartnerId { get; set; }

        public IEnumerable<SelectListItem> PartnerNumberSelection { get; set; }
    }
}

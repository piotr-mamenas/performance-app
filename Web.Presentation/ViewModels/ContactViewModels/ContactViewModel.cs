using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Core.Domain.Partners;

namespace Web.Presentation.ViewModels.ContactViewModels
{
    public class ContactViewModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Contact Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Related Partner")]
        public int SelectedPartnerId { get; set; }
        
        public IEnumerable<SelectListItem> PartnerNumberSelection { get; set; }
    }
}
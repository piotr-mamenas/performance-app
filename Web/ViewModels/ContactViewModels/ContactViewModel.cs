using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.ContactViewModels
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
        [RegularExpression(@"\+?[0-9]{10}", ErrorMessage = "Please provide a valid phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Related Partner")]
        public int SelectedPartnerId { get; set; }
        
        public IEnumerable<SelectListItem> PartnerNumberSelection { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Partners;

namespace Web.ViewModels.Contact
{
    public class ContactViewModel
    {
        public int Id { get; set; }

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

        [Required]
        [DisplayName("Contact Partner")]
        public virtual Partner Partner { get; set; }

        [DisplayName("Partner Id")]
        public int PartnerId { get; set; }
    }
}
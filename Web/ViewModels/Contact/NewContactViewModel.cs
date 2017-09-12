using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Dtos;

namespace Web.ViewModels.Contact
{
    public class NewContactViewModel
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Contact Partner")]
        public virtual PartnerDto Partner { get; set; }

        [DisplayName("Partner Id")]
        public int PartnerId { get; set; }
    }
}
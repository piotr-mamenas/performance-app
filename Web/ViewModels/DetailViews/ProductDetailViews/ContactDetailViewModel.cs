using System.ComponentModel;
using Core.Dtos;

namespace Web.ViewModels.DetailViews.ProductDetailViews
{
    public class ContactDetailViewModel
    {
        [DisplayName("Contact Name")]
        public string Name { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
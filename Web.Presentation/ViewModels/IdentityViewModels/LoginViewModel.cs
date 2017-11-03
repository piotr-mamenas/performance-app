using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Presentation.ViewModels.IdentityViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User")]
        public string Username { get; set; }
        
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}

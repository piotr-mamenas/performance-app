using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Presentation.ViewModels.IdentityViewModels
{
    /// <summary>
    /// View model used to post a login request to the application
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User")]
        public string Username { get; set; }
        
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me?")]
        public bool IsPersistent { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [DisplayName("Username")]
        public string UserName { get; set; }
        public bool RememberMe { get; set; }

        [Required(ErrorMessage ="Please enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage ="Please enter your first name.")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter your last name.")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your e-mail address.")]
        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your phone number.")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Passwords must match.")]
        public string ConfirmPassword { get; set; }

    }
}

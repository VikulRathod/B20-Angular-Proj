using System.ComponentModel.DataAnnotations;

namespace edTechSpark.Models
{
    public class UserSignUpModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.User
{
    public class LoginDto
    {
        [Required]
        [RegularExpression(@"^[^@#\$]*$", ErrorMessage = "Username cannot contain @, #, or $.")]

        public string UserName { get; set; }

        [Required]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,50}$",
            ErrorMessage = "Password must be at least 8 characters long and at most 50 characters, contain an uppercase, a lowercase, a digit, and a special character."
        )]
        public string Password { get; set; }
    }
}

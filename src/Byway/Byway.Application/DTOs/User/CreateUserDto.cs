using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.User
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(25, ErrorMessage = "FirstName cannot exceed 25 characters length")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "LastName cannot exceed 25 characters length")]

        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[^@#\$]*$", ErrorMessage = "Username cannot contain @, #, or $.")]
        [MaxLength(25, ErrorMessage = "Username cannot exceed 25 characters length")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$",
            ErrorMessage = "Password must be at least 8 characters long and at most 30 characters, contain an uppercase, a lowercase, a digit, and a special character."
        )]
        public string Password { get; set; }
    }
}

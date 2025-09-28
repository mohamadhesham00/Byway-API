using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.User
{
    public class LoginDto
    {
        [Required]
        public string UserNameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Garten.Core.Models.Login
{
    public class LoginRequestDto
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
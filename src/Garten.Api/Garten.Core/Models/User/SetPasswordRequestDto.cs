using System.ComponentModel.DataAnnotations;

namespace Garten.Core.Models.User
{
    public class SetPasswordRequestDto
    {
        [Required]
        public string Password { get; set; }
    }
}

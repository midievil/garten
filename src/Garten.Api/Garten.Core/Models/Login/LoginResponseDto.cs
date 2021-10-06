using Garten.Common.Models.User;

namespace Garten.Core.Models.Login
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserRoles Role { get; set; }
    }
}

using Garten.Core.Models.Login;
using System.Threading.Tasks;

namespace Garten.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request);
        Task<LoginResponseDto> LoginAdminAsync(LoginRequestDto request);
    }
}
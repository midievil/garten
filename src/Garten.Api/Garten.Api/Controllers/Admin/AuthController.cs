using Garten.Core.Models.Login;
using Garten.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Garten.Api.Controllers.Admin
{
    [AllowAnonymous]
    public class AuthController : BaseAdminController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> LoginPhone(LoginRequestDto request)
        {
            return await ProcessResultAsync(() => _authService.LoginAdminAsync(request));
        }
    }
}

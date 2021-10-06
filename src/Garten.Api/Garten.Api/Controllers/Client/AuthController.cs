using Garten.Api.Controllers.Client;
using Garten.Core.Models.Login;
using Garten.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zing.Auth.Api.Controllers.Base;

namespace Garten.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseClientController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> LoginPhone(LoginRequestDto request)
        {
            return await ProcessResultAsync(() => _authService.LoginUserAsync(request));
        }
    }
}
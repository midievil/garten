using Garten.Core.Models.User;
using Garten.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Garten.Api.Controllers.Client
{
    public class UsersController : BaseClientController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserViewDto>> GetCurrentProfile()
        {
            return await ProcessResultAsync(() => _userService.GetUserByIdAsync(CurrentUserId.Value));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewDto>> GetById([FromRoute] Guid id)
        {
            return await ProcessResultAsync(() => _userService.GetUserByIdAsync(id));
        }
    }
}

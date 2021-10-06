using Garten.Core.Models.Filter;
using Garten.Core.Models.User;
using Garten.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garten.Api.Controllers.Admin
{
    public class UsersController : BaseAdminController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewDto>>> GetUsers([FromQuery] SortParamsDto sort)
        {
            return await ProcessResultAsync(() => _userService.ListUsersAsync(sort));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewDto>> AddUser([FromBody] UserEditDto request)
        {
            return await ProcessResultAsync(() => _userService.CreateUserAsync(request, CurrentUserId.Value));
        }
    }
}

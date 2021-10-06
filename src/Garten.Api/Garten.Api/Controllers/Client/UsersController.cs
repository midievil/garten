using Garten.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Garten.Api.Controllers.Client
{
    public class UsersController : BaseClientController
    {
        [HttpGet("me")]
        public async Task<ActionResult<UserViewDto>> GetCurrentProfile()
        {
            return Ok(new UserViewDto { });
        }
    }
}

using Garten.Common.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zing.Auth.Api.Controllers.Base;

namespace Garten.Api.Controllers.Admin
{
    [Area("admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public abstract class BaseAdminController : BaseController
    {
    }
}

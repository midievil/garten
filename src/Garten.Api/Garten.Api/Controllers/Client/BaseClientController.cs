using Garten.Common.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zing.Auth.Api.Controllers.Base;

namespace Garten.Api.Controllers.Client
{
    [Area("client")]
    [Authorize(Roles = nameof(UserRoles.Parent) + "," + nameof(UserRoles.Commitee))]
    public abstract class BaseClientController : BaseController
    {
    }
}

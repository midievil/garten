using Garten.Common.Models.User;
using System.Collections.Generic;

namespace Garten.Core.Models.User
{
    public class UserEditDto : BasePersonDto
    {
        public long? Phone { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserRoles> Roles { get; set; }
    }
}

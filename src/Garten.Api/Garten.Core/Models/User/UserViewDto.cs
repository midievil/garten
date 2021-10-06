using Garten.Common.Models.User;
using System;
using System.Collections.Generic;

namespace Garten.Core.Models.User
{
    public class UserViewDto : BasePersonDto
    {
        public Guid Id { get; set; }
        public long? Phone { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public IEnumerable<UserRoles> Roles { get; set; }
    }
}

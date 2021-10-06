using Garten.Common.Models.User;
using System;
using System.Collections.Generic;

namespace Garten.Database.Entities
{
    public class User : BasePerson
    {
        public long Phone { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserKid> Kids { get; set; }
        public UserRoles[] Roles { get; set; }
        public DateTime? DateLastLogin { get; set; }
    }
}
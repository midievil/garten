using System;

namespace Garten.Database.Entities
{
    public class Admin : BaseEntity
    {
        public long Phone { get; set; }
        public string Password { get; set; }
    }
}

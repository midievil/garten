using System;

namespace Garten.Database.Entities
{
    public class Kid : BasePerson
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}

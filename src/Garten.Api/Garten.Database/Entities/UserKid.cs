using System;

namespace Garten.Database.Entities
{
    public class UserKid : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid KidId { get; set; }
        public Kid Kid { get; set; }
    }
}
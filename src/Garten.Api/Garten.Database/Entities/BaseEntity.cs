using System;

namespace Garten.Database
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatorId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
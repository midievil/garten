using System;
using System.ComponentModel.DataAnnotations;

namespace Garten.Database.Entities
{
    public abstract class BasePerson : BaseEntity
    {
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
    }
}

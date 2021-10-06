using System.ComponentModel.DataAnnotations;

namespace Garten.Core.Models
{
    public class BasePersonDto
    {
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
    }
}

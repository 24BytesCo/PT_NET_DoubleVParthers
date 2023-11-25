using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _4.Domain
{
    public class Usuario : IdentityUser
    {
        [Key]
        public Guid Identificador { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}

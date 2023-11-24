using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Domain
{
    public class Usuario : IdentityUser
    {
        [Key]
        public Guid Identificador { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}

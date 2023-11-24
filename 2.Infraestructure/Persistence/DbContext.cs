using _4.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Infraestructure.Persistence
{
    public class DbContext: IdentityDbContext<Usuario>
    {
        public DbContext(DbContextOptions<DbContext> options): base(options)
        {}

        public DbSet<Persona>? Personas { get; set; }

    }
}

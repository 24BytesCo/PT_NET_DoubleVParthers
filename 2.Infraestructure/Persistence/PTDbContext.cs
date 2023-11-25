using _4.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2.Infraestructure.Persistence
{
    public class PTDbContext : IdentityDbContext<Usuario>
    {
        public PTDbContext(DbContextOptions<PTDbContext> options) : base(options)
        { }

        public DbSet<Persona>? Personas { get; set; }

    }
}

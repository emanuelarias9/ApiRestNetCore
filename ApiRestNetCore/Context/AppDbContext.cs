using ApiRestNetCore.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}

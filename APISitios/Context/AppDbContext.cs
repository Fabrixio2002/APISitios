using APISitios.Models;
using Microsoft.EntityFrameworkCore;

namespace APISitios.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        public DbSet<Sitios>Sitios { get; set; }
    }
}

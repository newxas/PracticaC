using Microsoft.EntityFrameworkCore;

namespace PracticaC_.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        { 
        }

        public DbSet<LineasCelular> LineasCelular { get; set; }
        public DbSet<DetalleLlamadas> DetalleLlamadas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}

using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Modelos.EntityType;
using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;

namespace ApiAirsoft.Util
{
    public class AirsoftDbContext : DbContext
    {
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Ropa> Ropas { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<Disparo> Disparos { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Lentes> Lentes { get; set; }

        public AirsoftDbContext(DbContextOptions<AirsoftDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            callCreating(modelBuilder);
        }

        private void callCreating(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ArmaEntityTypeConfiguration).Assembly);
    }
}
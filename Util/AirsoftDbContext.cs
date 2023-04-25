using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Modelos.EntityType;
using Microsoft.EntityFrameworkCore;

namespace ApiAirsoft.Util
{
    public class AirsoftDbContext : DbContext
    {
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Accesorio> Accesorios { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Disparo> Disparos { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        public AirsoftDbContext(DbContextOptions<AirsoftDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            callCreatingArma(modelBuilder);
            callCreatingAccesorio(modelBuilder);
            callCreatingDisparo(modelBuilder);
            callCreatingColor(modelBuilder);
            callCreatingPedido(modelBuilder);
            callCreatingCliente(modelBuilder);
            callCreatingAccion(modelBuilder);
        }

        private void callCreatingArma(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ArmaEntityTypeConfiguration).Assembly);
        private void callCreatingCliente(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ClientesEntityTypeConfiguration).Assembly);
        private void callCreatingPedido(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(PedidosEntityTypeConfiguration).Assembly);
        private void callCreatingAccesorio(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AccesorioEntityTypeConfiguration).Assembly);
        private void callCreatingColor(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ColorEntityTypeConfiguration).Assembly);
        private void callCreatingAccion(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AccionEntityTypeConfiguration).Assembly);
        private void callCreatingDisparo(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DisparoEntityTypeConfiguration).Assembly);
    }
}
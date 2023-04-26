using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class ClientesEntityTypeConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(c => c.Cod_Cliente);
            builder.Property(c=>c.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Apellido1).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Apellido2).IsRequired().HasMaxLength(100);
            builder.Property(c=>c.Gmail).IsRequired();
            builder.Property(c => c.Telefono);

            builder.HasMany(c => c.Pedidos)
                   .WithOne()
                   .HasForeignKey(p => p.Cod_Cliente)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

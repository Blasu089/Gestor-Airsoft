using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class PedidosEntityTypeConfiguration : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasKey(p => p.Cod_Pedido);
            builder.Property(p => p.Cod_Cliente).IsRequired();
            builder.Property(p => p.Precio_Total).IsRequired();

            builder.HasMany(p => p.Armas)
                   .WithOne()
                   .HasForeignKey(a => a.Cod_Pedido)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Accesorios)
                   .WithOne()
                   .HasForeignKey(ac => ac.Cod_Pedido)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

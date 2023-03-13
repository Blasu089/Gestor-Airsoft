using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class RopaEntityTypeConfiguration : IEntityTypeConfiguration<Ropa>
    {
        public void Configure(EntityTypeBuilder<Ropa> builder)
        {
            builder.HasKey(r => r.Cod_Ropa);
            builder.Property(r => r.Marca).IsRequired().HasMaxLength(50);
            builder.Property(r=>r.Modelo).IsRequired().HasMaxLength(50);
            builder.Property(r=>r.Material).HasMaxLength(50);
            builder.Property(r=>r.Precio).IsRequired();

            builder.HasMany(r => r.Colores)
                   .WithMany(c => c.Ropas);

            builder.HasMany(r => r.Tallas)
                   .WithMany(t => t.Ropas);

            builder.HasDiscriminator<string>("Tipo Ropa")
                   .HasValue<Botas>("Botas")
                   .HasValue<Camiseta>("Camiseta")
                   .HasValue<Casco>("Casco")
                   .HasValue<Chaleco>("Chaleco")
                   .HasValue<Gafas>("Gafas")
                   .HasValue<Guantes>("Guantes")
                   .HasValue<Mascara>("Mascara")
                   .HasValue<Pantalon>("Pantalon");

        }
    }
}

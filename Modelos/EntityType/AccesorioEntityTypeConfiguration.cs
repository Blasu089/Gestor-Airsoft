using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class AccesorioEntityTypeConfiguration : IEntityTypeConfiguration<Accesorio>
    {
        public void Configure(EntityTypeBuilder<Accesorio> builder)
        {
            builder.HasKey(ac => ac.Cod_Accesorio);
            builder.Property(ac => ac.Modelo).IsRequired().HasMaxLength(50);
            builder.Property(ac => ac.Serie).IsRequired().HasMaxLength(50);
            builder.Property(ac => ac.Marca).IsRequired().HasMaxLength(50);
            builder.Property(ac => ac.Material).HasMaxLength(50);
            builder.Property(ac => ac.Tipo).IsRequired().HasMaxLength(50);
            builder.Property(ac => ac.Precio).IsRequired();
            builder.Property(ac => ac.Foto);
        }
    }
}

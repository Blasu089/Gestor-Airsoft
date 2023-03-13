using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class AccionEntityTypeConfiguration : IEntityTypeConfiguration<Accion>
    {
        public void Configure(EntityTypeBuilder<Accion> builder)
        {
            builder.HasKey(acci => acci.Cod_Accion);
            builder.Property(acci => acci.Tipo).IsRequired().HasMaxLength(50);
        }
    }
}

using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
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

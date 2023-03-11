using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class EscopetaEntityTypeConfiguration : IEntityTypeConfiguration<Escopeta>
    {
        public void Configure(EntityTypeBuilder<Escopeta> builder)
        {
            builder.Property(e=>e.Capacidad_Cartucho).IsRequired();
            builder.Property(e=>e.Cartuchos_Incluidos).IsRequired().HasDefaultValue(false);
        }
    }
}

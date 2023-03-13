using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class MascaraEntityTypeConfiguration : IEntityTypeConfiguration<Mascara>
    {
        public void Configure(EntityTypeBuilder<Mascara> builder)
        {
            builder.Property(m => m.Peso);
            builder.Property(m => m.FullFace).IsRequired().HasDefaultValue(false);
        }
    }
}

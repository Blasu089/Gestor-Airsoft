using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class CascoEntityTypeConfiguration : IEntityTypeConfiguration<Casco>
    {
        public void Configure(EntityTypeBuilder<Casco> builder)
        {
            builder.Property(cas => cas.Peso);
            builder.Property(cas=>cas.Rieles_Laterales).IsRequired().HasDefaultValue(false);
            builder.Property(cas=>cas.Acolchado).IsRequired().HasDefaultValue(false);
            builder.Property(cas=>cas.Riel_Frontal).IsRequired().HasDefaultValue(false);
        }
    }
}

using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class CamisetaEntityTypeConfiguration : IEntityTypeConfiguration<Camiseta>
    {
        public void Configure(EntityTypeBuilder<Camiseta> builder)
        {
            builder.Property(ca=>ca.Manga_Larga).IsRequired().HasDefaultValue(false);
        }
    }
}

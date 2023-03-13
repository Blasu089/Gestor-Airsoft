using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class GafasEntityTypeConfiguration : IEntityTypeConfiguration<Gafas>
    {
        public void Configure(EntityTypeBuilder<Gafas> builder)
        {
            builder.HasMany(g => g.Lentes)
                   .WithMany(l => l.Gafas);
        }
    }
}

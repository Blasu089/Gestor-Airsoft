using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class ChalecoEntityTypeConfiguration : IEntityTypeConfiguration<Chaleco>
    {
        public void Configure(EntityTypeBuilder<Chaleco> builder)
        {
            builder.Property(ch=>ch.Num_Portacargadores).IsRequired().HasDefaultValue(0);
        }
    }
}

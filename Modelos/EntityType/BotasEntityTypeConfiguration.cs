using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class BotasEntityTypeConfiguration : IEntityTypeConfiguration<Botas>
    {
        public void Configure(EntityTypeBuilder<Botas> builder)
        {
            builder.Property(b=>b.Revestimiento_Metalico).IsRequired().HasDefaultValue(false);
        }
    }
}

using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class GuantesEntityTypeConfiguration : IEntityTypeConfiguration<Guantes>
    {
        public void Configure(EntityTypeBuilder<Guantes> builder)
        {
            builder.Property(gu=>gu.Mitones).IsRequired().HasDefaultValue(false);
        }
    }
}

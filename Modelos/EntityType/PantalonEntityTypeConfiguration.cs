using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class PantalonEntityTypeConfiguration : IEntityTypeConfiguration<Pantalon>
    {
        public void Configure(EntityTypeBuilder<Pantalon> builder)
        {
            builder.Property(p=>p.Num_Bolsillos).IsRequired().HasDefaultValue(2);
        }
    }
}

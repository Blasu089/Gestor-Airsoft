using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class TallaEntityTypeConfiguration : IEntityTypeConfiguration<Talla>
    {
        public void Configure(EntityTypeBuilder<Talla> builder)
        {
            builder.HasKey(t => t.Cod_Talla);
            builder.Property(t => t.Talla_Europea).IsRequired();
            builder.Property(t=>t.Talla_Americana).IsRequired().HasMaxLength(50);
        }
    }
}

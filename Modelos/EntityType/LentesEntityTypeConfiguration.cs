using ApiAirsoft.Modelos.Ropas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class LentesEntityTypeConfiguration : IEntityTypeConfiguration<Lentes>
    {
        public void Configure(EntityTypeBuilder<Lentes> builder)
        {
            builder.HasKey(l => l.Cod_Lentes);
            builder.Property(l => l.Tipo).IsRequired().HasMaxLength(50);
        }
    }
}

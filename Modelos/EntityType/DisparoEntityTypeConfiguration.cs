using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class DisparoEntityTypeConfiguration : IEntityTypeConfiguration<Disparo>
    {
        public void Configure(EntityTypeBuilder<Disparo> builder)
        {
            builder.HasKey(d => d.Cod_Disparo);
            builder.Property(d => d.Tipo).IsRequired().HasMaxLength(50);
        }
    }
}

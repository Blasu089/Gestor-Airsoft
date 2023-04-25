using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{

    public class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.Cod_Color);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Hexadecimal).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Armas)
                   .WithOne()
                   .HasForeignKey(a => a.Color_Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Accesorios)
                   .WithOne()
                   .HasForeignKey(ac => ac.Color_Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

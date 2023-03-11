using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{

    public class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
            builder.HasKey(c => c.Cod_Color);
            builder.Property(c=>c.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(c=>c.Hexadecimal).IsRequired().HasMaxLength(50);

    }
}
}

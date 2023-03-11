using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class FrancotiradorEntityTypeConfiguration : IEntityTypeConfiguration<Francotirador>
    {
        public void Configure(EntityTypeBuilder<Francotirador> builder)
        {
            builder.Property(f => f.Bipode_Incluido).IsRequired().HasDefaultValue(false);
            builder.Property(f => f.Mira_Incluida).IsRequired().HasDefaultValue(false);

        }
    }
}

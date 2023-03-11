using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class PistolaEntityTypeConfiguration : IEntityTypeConfiguration<Pistola>
    {
        public void Configure(EntityTypeBuilder<Pistola> builder)
        {
            
        }
    }
}

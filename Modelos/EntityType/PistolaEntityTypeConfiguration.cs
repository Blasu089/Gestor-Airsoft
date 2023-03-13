using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class PistolaEntityTypeConfiguration : IEntityTypeConfiguration<Pistola>
    {
        public void Configure(EntityTypeBuilder<Pistola> builder)
        {

        }
    }
}

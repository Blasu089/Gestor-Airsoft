using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class FusilEntityTypeConfiguration : IEntityTypeConfiguration<Fusil>
    {
        public void Configure(EntityTypeBuilder<Fusil> builder)
        {

        }
    }
}

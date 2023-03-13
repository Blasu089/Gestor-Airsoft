using ApiAirsoft.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAirsoft.Modelos.EntityType
{
    public class SubfusilEntityTypeConfiguration : IEntityTypeConfiguration<Subfusil>
    {
        public void Configure(EntityTypeBuilder<Subfusil> builder)
        {

        }
    }
}

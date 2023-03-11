using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class SubfusilEntityTypeConfiguration : IEntityTypeConfiguration<Subfusil>
    {
        public void Configure(EntityTypeBuilder<Subfusil> builder)
        {
            
        }
    }
}

using Api.Modelos.Armas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modelos.EntityType
{
    public class FusilEntityTypeConfiguration : IEntityTypeConfiguration<Fusil>
    {
        public void Configure(EntityTypeBuilder<Fusil> builder)
        {
            
        }
    }
}

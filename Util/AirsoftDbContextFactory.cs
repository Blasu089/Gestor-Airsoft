using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Util
{
    public class AirsoftDbContextFactory : IDesignTimeDbContextFactory<AirsoftDbContext>
    {
        public AirsoftDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AirsoftDbContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-S7AM7PC\\SQLEXPRESS;database=Airsoft2;user id=sa; password=A1234; MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();

            return new AirsoftDbContext(optionsBuilder.Options);
        }
    }
}

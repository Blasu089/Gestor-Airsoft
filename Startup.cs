using ApiAirsoft.Servicios.IServices;
using ApiAirsoft.Util;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiAirsoft
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AirsoftDbContext>(opt => {
                opt.UseSqlServer("name=ConnectionStrings:DB1");
                opt.UseLazyLoadingProxies();
            });

            //services.AddScoped<IMapper, Mapper>();

            /*Repositories*/
            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            //services.AddScoped<IArmaService, ArmaService>();

            services.AddMvc();

            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Api.Util;
using System.Reflection;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AirsoftDbContext>();

            //services.AddScoped<IMapper, Mapper>();

            /*Repositories*/
            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            //services.AddScoped<IVehiculeService, VehiculeService>();

            services.AddMvc();

            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwagger();

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

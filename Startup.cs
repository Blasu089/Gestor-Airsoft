using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;
using ApiAirsoft.Servicios.Services;
using ApiAirsoft.Util;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiAirsoft
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            /**
             * Llamada a la BBDD para conectarse a esta
             */
            services.AddDbContext<AirsoftDbContext>(opt => {
                opt.UseSqlServer("name=ConnectionStrings:DB2");
            });

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            /*BussinessLogical*/
            services.AddScoped(typeof(IRepositorio<,>), typeof(Repositorio<,>));
            services.AddScoped<IArmaService<Arma>, ArmaService>();
            services.AddScoped<IAccionService<Accion>, AccionService>();
            services.AddScoped<IAccesorioService<Accesorio>, AccesorioService>();
            services.AddScoped<IColorService<Color>, ColorService>();
            services.AddScoped<IDisparoService<Disparo>, DisparoService>();
            services.AddScoped<IClienteService<Clientes>, ClienteService>();
            services.AddScoped<IPedidosService<Pedidos>, PedidosService>();


            services.AddMvc();

            /**
             * Llamada a metodo para que no haya un bucle a la hora de las peticiones, si
             * no se usase a la hora de pedir un dato con relacion ManyToMany mostraria a
             * su vez sus relaciones con otros campos haciendo asi un bucle infinito
             */
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
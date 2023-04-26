using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class ColorService : IColorService<Color>
    {
        private readonly IRepositorio<int, Color> repositorio;
        private readonly IArmaService<Arma> armaService;
        private readonly IAccesorioService<Accesorio> accesorioService;

        public ColorService(IRepositorio<int, Color> repositorio, IArmaService<Arma> armaService,
            IAccesorioService<Accesorio> accesorioService)
        {
            this.repositorio = repositorio;
            this.armaService = armaService;
            this.accesorioService = accesorioService;
        }

        public ICollection<Color> GetAll()
        {
            var colores_list = new List<Color>();
            var colores = repositorio.Get().ToList();
            foreach (var color in colores)
            {
                gestionarAccesorios(accesorioService, color);
                gestionarArmas(armaService, color);
                colores_list.Add(color);
            }
            return colores_list;
        }

        public Color? GetById(int? id)
        {
            var color = repositorio.Where(c => c.Cod_Color == id).SingleOrDefault();
            if (color != null)
            {
                gestionarAccesorios(accesorioService, color);
                gestionarArmas(armaService, color);
                return color;
            }
            else return color;
        }

        public bool Post(Color entity)
        {
            if (entity != null)
            {
                gestionarArmas(armaService, entity);
                gestionarAccesorios(accesorioService, entity);
                return repositorio.Add(entity);
            }
            else return false;
        }

        public bool Put(Color entity)
        {
            if (entity != null)
            {
                gestionarArmas(armaService, entity);
                gestionarAccesorios(accesorioService, entity);
                return repositorio.Update(entity);
            }
            else return false;
        }

        public bool Delete(Color entity) => repositorio.Delete(entity.Cod_Color);

        public void gestionarArmas(IArmaService<Arma> armaService, Color color)
        {
            var armas = armaService.GetAll().Where(a => a.Color_Id == color.Cod_Color);
            if (armas != null)
            {
                foreach (var arma in armas)
                {
                    if (color.Armas == null) color.Armas = new List<Arma> { arma };
                    else color.Armas.Add(arma);
                }
            }
        }
        public void gestionarAccesorios(IAccesorioService<Accesorio> accesorioService, Color color)
        {
            var accesorios = accesorioService.GetAll().Where(ac => ac.Color_Id == color.Cod_Color);
            if (accesorios != null)
            {
                foreach (var accesorio in accesorios)
                {
                    if (color.Accesorios == null) color.Accesorios = new List<Accesorio> { accesorio };
                    else color.Accesorios.Add(accesorio);
                }
            }
        }

    }
}
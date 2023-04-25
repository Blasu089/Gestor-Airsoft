using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class AccesorioService : IAccesorioService<Accesorio>
    {
        private readonly IRepositorio<int, Accesorio> repositorio;
        private readonly IColorService<Color> colorService;

        public AccesorioService(IRepositorio<int, Accesorio> repositorio,IColorService<Color> colorService) 
        { 
            this.repositorio = repositorio; 
            this.colorService = colorService;
        }

        public ICollection<Accesorio> GetAll() 
        {
            var accesorio_list= new List<Accesorio>();

            var accesorios = repositorio.Get();

            foreach (var accesorio in accesorios)
            {

                gestionarColor(colorService, accesorio, true);

                accesorio_list.Add(accesorio);
            }

            return accesorio_list;
        }

        public Accesorio? GetById(int? id)
        {
            var accesorio = repositorio.Get(id).Where(c => c.Cod_Accesorio == id).SingleOrDefault();
            if(accesorio != null)
            {
                gestionarColor(colorService, accesorio, true);

                return accesorio;
            }
            else return accesorio;
        }

        public bool Post(Accesorio entity) 
        {
            if (entity != null)
            {
                if (entity.Color_Id != null) gestionarColor(colorService, entity, true);

                repositorio.Add(entity);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Put(Accesorio entity) => repositorio.Update(entity);

        public bool Delete(Accesorio entity) => repositorio.Delete(entity.Cod_Accesorio);

        private void gestionarColor(IColorService<Color> colorService, Accesorio entity, bool flag)
        {
            var colores = colorService.GetAll();
            var color = colores.Where(c => c.Cod_Color == entity.Color_Id).FirstOrDefault();
            if (color != null)
            {
                entity.Color_Id = color.Cod_Color;
                if (flag)
                {
                    if (color.Accesorios == null) color.Accesorios = new List<Accesorio> { entity };
                    else color.Accesorios.Add(entity);
                }
            }
        }
    }
}
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;
using Microsoft.EntityFrameworkCore;

namespace ApiAirsoft.Servicios.Services
{
    public class AccionService : IAccionService<Accion>
    {
        private readonly IRepositorio<int, Accion> repositorio;

        public AccionService(IRepositorio<int, Accion> repositorio)
        {
            this.repositorio = repositorio;
        }

        public ICollection <Accion> GetAll() => repositorio.Get().ToList();

        public Accion? GetById(int? id) => repositorio.Where(c => c.Cod_Accion == id).SingleOrDefault();

        public bool Post(Accion entity) => repositorio.Add(entity);

        public bool Put(Accion entity) => repositorio.Update(entity);

        public bool Delete(Accion entity) => repositorio.Delete(entity.Cod_Accion);
    }
}
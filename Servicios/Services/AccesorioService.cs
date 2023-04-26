using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class AccesorioService : IAccesorioService<Accesorio>
    {
        private readonly IRepositorio<int, Accesorio> repositorio;

        public AccesorioService(IRepositorio<int, Accesorio> repositorio) 
        { 
            this.repositorio = repositorio; 
        }

        public ICollection<Accesorio> GetAll() => repositorio.Get().ToList();

        public Accesorio? GetById(int? id) => repositorio.Get(id).Where(c => c.Cod_Accesorio == id).SingleOrDefault();

        public bool Post(Accesorio entity) => entity != null ? repositorio.Add(entity) : false;

        public bool Put(Accesorio entity) => entity != null ? repositorio.Update(entity) : false;

        public bool Delete(Accesorio entity) => repositorio.Delete(entity.Cod_Accesorio);
    }
}
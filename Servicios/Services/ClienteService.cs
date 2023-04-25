using ApiAirsoft.Modelos;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class ClienteService : IClienteService<Clientes>
    {
        
        private readonly IRepositorio<int, Clientes> repositorio;

        public ClienteService(IRepositorio<int, Clientes> repositorio)
        {
            this.repositorio = repositorio;
        }

        public ICollection<Clientes> GetAll()=>repositorio.Get().ToList();

        public Clientes? GetById(int? id)=>repositorio.Where(cl=>cl.Cod_Cliente==id).SingleOrDefault();

        public bool Post(Clientes entity)=>repositorio.Add(entity);

        public bool Put(Clientes entity)=>repositorio.Update(entity);

        public bool Delete(Clientes entity) => repositorio.Delete(entity.Cod_Cliente);
    }
}

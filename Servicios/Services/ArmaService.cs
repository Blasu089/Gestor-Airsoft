using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class ArmaService : IArmaService<Arma>
    {
        private readonly IRepositorio<Arma> repositorio;

        public ArmaService(IRepositorio<Arma> repositorio) { this.repositorio = repositorio; }

        public ICollection<Arma> GetAll() => repositorio.Get().ToList();

        public Arma? GetById(int id) => repositorio.Where(c => c.Cod_Referencia == id).SingleOrDefault();

        public bool Post(Arma entity) => repositorio.Add(entity);

        public bool Put(Arma entity) => repositorio.Update(entity);

        public bool Delete(Arma entity) => repositorio.Delete(entity);
    }
}
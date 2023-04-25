using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class DisparoService : IDisparoService<Disparo>
    {
        private readonly IRepositorio<int, Disparo> repositorio;

        public DisparoService(IRepositorio<int, Disparo> repositorio) { this.repositorio = repositorio; }

        public ICollection<Disparo> GetAll() => repositorio.Get().ToList();

        public Disparo? GetById(int? id) => repositorio.Where(c => c.Cod_Disparo == id).SingleOrDefault();

        public bool Post(Disparo entity) => repositorio.Add(entity);

        public bool Put(Disparo entity) => repositorio.Update(entity);

        public bool Delete(Disparo entity) => repositorio.Delete(entity.Cod_Disparo);
    }
}
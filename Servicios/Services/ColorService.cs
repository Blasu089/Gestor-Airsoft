using ApiAirsoft.Modelos;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class ColorService : IColorService<Color>
    {
        private readonly IRepositorio<int, Color> repositorio;

        public ColorService(IRepositorio<int, Color> repositorio) { this.repositorio = repositorio; }

        public ICollection<Color> GetAll() => repositorio.Get().ToList();

        public Color? GetById(int? id) => repositorio.Where(c => c.Cod_Color == id).SingleOrDefault();

        public bool Post(Color entity) => repositorio.Add(entity);

        public bool Put(Color entity) => repositorio.Update(entity);

        public bool Delete(Color entity) => repositorio.Delete(entity.Cod_Color);
    }
}
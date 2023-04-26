using ApiAirsoft.Modelos;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class UsuarioService : IUsuarioService<Usuario>
    {
        private IRepositorio<int, Usuario> repositorio;
        private readonly IEncriptacion encriptacion;

        public UsuarioService(IRepositorio<int, Usuario> repositorio, IEncriptacion encriptacion)
        {
            this.repositorio = repositorio;
            this.encriptacion = encriptacion;
        }

        public ICollection<Usuario> GetAll() => repositorio.Get().ToList();

        public Usuario? GetById(int? id) => repositorio.Get(id).Where(u => u.Cod_Usuario == id).SingleOrDefault();

        public bool Post(Usuario entity)
        {
            if (entity != null)
            {
                entity.Password = encriptacion.GetSHA256(entity.Password);
                return repositorio.Add(entity);
            }
            else return false;
        }

        public bool Put(Usuario entity)
        {
            if (entity != null)
            {
                entity.Password = encriptacion.GetSHA256(entity.Password);
                return repositorio.Update(entity);
            }
            else return false;
        }
        public bool Delete(Usuario entity) => repositorio.Delete(entity.Cod_Usuario);
    }
}
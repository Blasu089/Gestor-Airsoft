using ApiAirsoft.Modelos;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IUsuarioService<T>: ICrudService<T> where T : Usuario
    {
    }
}

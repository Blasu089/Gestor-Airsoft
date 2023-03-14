

using ApiAirsoft.Modelos.Armas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IArmaService<T>:ICrudService<T> where T : Arma
    {
        
    }
}

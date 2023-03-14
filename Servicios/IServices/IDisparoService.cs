using ApiAirsoft.Modelos.Armas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IDisparoService<T>:ICrudService<T> where T : Disparo
    {
    }
}

using ApiAirsoft.Modelos.Armas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IAccesorioService<T> : ICrudService<T> where T : Accesorio
    {
    }
}

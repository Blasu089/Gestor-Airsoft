using ApiAirsoft.Modelos.Armas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IAccionService<T> : ICrudService<T> where T : Accion
    {
    }
}

using ApiAirsoft.Modelos.Ropas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IRopaService<T>:ICrudService<T> where T : Ropa
    {

    }
}

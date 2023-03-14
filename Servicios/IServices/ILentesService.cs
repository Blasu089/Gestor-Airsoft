using ApiAirsoft.Modelos.Ropas;

namespace ApiAirsoft.Servicios.IServices
{
    public interface ILentesService<T>:ICrudService<T> where T : Lentes
    {

    }
}

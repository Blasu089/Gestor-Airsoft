using ApiAirsoft.Modelos;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IColorService<T>:ICrudService<T> where T : Color   
    {
    }
}

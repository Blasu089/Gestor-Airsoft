using ApiAirsoft.Modelos;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IClienteService<T>:ICrudService<T> where T : Clientes
    {
    }
}

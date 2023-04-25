using ApiAirsoft.Modelos;

namespace ApiAirsoft.Servicios.IServices
{
    public interface IPedidosService<T> : ICrudService<T> where T : Pedidos
    {
    }
}

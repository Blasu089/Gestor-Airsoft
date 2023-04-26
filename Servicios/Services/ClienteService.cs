using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class ClienteService : IClienteService<Clientes>
    {

        private readonly IRepositorio<int, Clientes> repositorio;
        private readonly IPedidosService<Pedidos> pedidosService;

        public ClienteService(IRepositorio<int, Clientes> repositorio, IPedidosService<Pedidos> pedidosService)
        {
            this.repositorio = repositorio;
            this.pedidosService = pedidosService;
        }

        public ICollection<Clientes> GetAll()
        {
            var clientes_list = new List<Clientes>();
            var clientes = repositorio.Get();
            foreach (var cliente in clientes)
            {
                gestionarPedidos(pedidosService, cliente);
                clientes_list.Add(cliente);
            }
            return clientes_list;
        }

        public Clientes? GetById(int? id)
        {
            var cliente = repositorio.Where(cl => cl.Cod_Cliente == id).SingleOrDefault();
            if (cliente != null)
            {
                gestionarPedidos(pedidosService, cliente);
                return cliente;
            }
            else return cliente;
        }

        public bool Post(Clientes entity)
        {
            if (entity != null)
            {
                gestionarPedidos(pedidosService, entity);
                repositorio.Add(entity);
                return true;
            }
            else return false;
        }

        public bool Put(Clientes entity)
        {
            if (entity != null)
            {
                gestionarPedidos(pedidosService, entity);
                repositorio.Update(entity);
                return true;
            }
            else return false;
        }

        public bool Delete(Clientes entity) => repositorio.Delete(entity.Cod_Cliente);

        public void gestionarPedidos(IPedidosService<Pedidos> pedidosService, Clientes cliente)
        {
            var pedidos = pedidosService.GetAll().Where(p => p.Cod_Cliente == cliente.Cod_Cliente);
            if (pedidos != null)
            {
                foreach (var pedido in pedidos)
                {
                    if (cliente.Pedidos == null) cliente.Pedidos = new List<Pedidos> { pedido };
                    else cliente.Pedidos.Add(pedido);
                }
            }
        }
    }
}

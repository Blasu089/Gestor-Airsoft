using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class PedidosService : IPedidosService<Pedidos>
    {
        private readonly IRepositorio<int, Pedidos> repositorio;
        private readonly IArmaService<Arma> armaService;
        private readonly IAccesorioService<Accesorio> accesorioService;
        private readonly IClienteService<Clientes> clienteService;

        public PedidosService(IRepositorio<int, Pedidos> repositorio, IArmaService<Arma> armaService,
            IAccesorioService<Accesorio> accesorioService, IClienteService<Clientes> clienteService)
        {
            this.repositorio = repositorio;
            this.armaService = armaService;
            this.accesorioService = accesorioService;
            this.clienteService = clienteService;
        }

        public ICollection<Pedidos> GetAll()
        {
            var pedidos_list = new List<Pedidos>();
            var pedidos = repositorio.Get();
            foreach (var pedido in pedidos)
            {
                gestionarAccesorios(accesorioService, pedido, false);
                gestionarArmas(armaService, pedido, false);
                gestionarClientes(clienteService, pedido, false);
                pedidos_list.Add(pedido);
            }
            return pedidos_list;
        }

        public Pedidos? GetById(int? id)
        {
            var pedido = repositorio.Get(id).Where(p => p.Cod_Pedido == id).FirstOrDefault();
            if (pedido != null)
            {
                gestionarAccesorios(accesorioService, pedido, false);
                gestionarArmas(armaService, pedido, false);
                gestionarClientes(clienteService, pedido, false);
                return pedido;
            }
            else return pedido;
        }

        public bool Post(Pedidos entity)
        {
            if (entity != null)
            {
                if (entity.Cod_Cliente != 0) gestionarClientes(clienteService, entity, true);
                if (entity.Armas != null) gestionarArmas(armaService, entity, true);
                if (entity.Accesorios != null) gestionarAccesorios(accesorioService, entity, true);
                repositorio.Add(entity);
                return true;
            }
            else return false;
        }

        public bool Put(Pedidos entity)
        {
            if (entity != null)
            {
                if (entity.Cod_Cliente != 0) gestionarClientes(clienteService, entity, false);
                if (entity.Armas != null) gestionarArmas(armaService, entity, false);
                if (entity.Accesorios != null) gestionarAccesorios(accesorioService, entity, false);
                repositorio.Update(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(Pedidos entity) => repositorio.Delete(entity.Cod_Pedido);

        #region metodos de gestion

        public void gestionarArmas(IArmaService<Arma> armaService, Pedidos pedido, bool flag)
        {
            var armas = armaService.GetAll();
            var arma = armas.Where(a => a.Cod_Pedido == pedido.Cod_Pedido).FirstOrDefault();
            if (arma != null)
            {
                arma.Cod_Pedido = pedido.Cod_Pedido;
                if (flag)
                {
                    if (pedido.Armas == null) pedido.Armas = new List<Arma> { arma };
                    else pedido.Armas.Add(arma);
                    pedido.Precio_Total = pedido.Precio_Total + arma.Precio;
                }
            }
        }

        public void gestionarAccesorios(IAccesorioService<Accesorio> accesorioService, Pedidos pedido, bool flag)
        {
            var accesorios = accesorioService.GetAll();

            var accesorio = accesorios.Where(ac => ac.Cod_Pedido == pedido.Cod_Pedido).FirstOrDefault();

            if (accesorio != null)
            {
                accesorio.Cod_Pedido = pedido.Cod_Pedido;
                if (flag)
                {
                    if (pedido.Accesorios == null) pedido.Accesorios = new List<Accesorio> { accesorio };
                    else pedido.Accesorios.Add(accesorio);
                    pedido.Precio_Total = pedido.Precio_Total + accesorio.Precio;
                }
            }
        }

        public void gestionarClientes(IClienteService<Clientes> clienteService, Pedidos pedido, bool flag)
        {
            var clientes = clienteService.GetAll();

            var cliente = clientes.Where(c => c.Cod_Cliente == pedido.Cod_Cliente).FirstOrDefault();

            if (cliente != null)
            {
                pedido.Cod_Cliente = cliente.Cod_Cliente;
                if (flag)
                {
                    if (cliente.Pedidos == null) cliente.Pedidos = new List<Pedidos> { pedido };
                    else cliente.Pedidos.Add(pedido);
                }
            }
        }

        #endregion
    }
}

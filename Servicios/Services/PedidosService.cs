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

        public PedidosService(IRepositorio<int, Pedidos> repositorio, IArmaService<Arma> armaService,
            IAccesorioService<Accesorio> accesorioService)
        {
            this.repositorio = repositorio;
            this.armaService = armaService;
            this.accesorioService = accesorioService;
        }

        public ICollection<Pedidos> GetAll()
        {
            var pedidos_list = new List<Pedidos>();
            var pedidos = repositorio.Get();
            foreach (var pedido in pedidos)
            {
                gestionarAccesorios(accesorioService, pedido);
                gestionarArmas(armaService, pedido);
                pedidos_list.Add(pedido);
            }
            return pedidos_list;
        }

        public Pedidos? GetById(int? id)
        {
            var pedido = repositorio.Get(id).Where(p => p.Cod_Pedido == id).FirstOrDefault();
            if (pedido != null)
            {
                gestionarAccesorios(accesorioService, pedido);
                gestionarArmas(armaService, pedido);
                return pedido;
            }
            else return pedido;
        }

        public bool Post(Pedidos entity)
        {
            if (entity != null)
            {
                if (entity.Armas != null) gestionarArmas(armaService, entity);
                if (entity.Accesorios != null) gestionarAccesorios(accesorioService, entity);
                calcularPrecio(entity, accesorioService, armaService);
                repositorio.Add(entity);
                return true;
            }
            else return false;
        }

        public bool Put(Pedidos entity)
        {
            if (entity != null)
            {
                if (entity.Armas != null) gestionarArmas(armaService, entity);
                if (entity.Accesorios != null) gestionarAccesorios(accesorioService, entity);
                calcularPrecio(entity, accesorioService, armaService);
                repositorio.Update(entity);
                return true;
            }
            else return false;
        }
        public bool Delete(Pedidos entity) => repositorio.Delete(entity.Cod_Pedido);

        #region metodos de gestion

        public void gestionarArmas(IArmaService<Arma> armaService, Pedidos pedido)
        {
            var armas = armaService.GetAll().Where(a => a.Cod_Pedido == pedido.Cod_Pedido);
            if (armas != null)
            {
                foreach(var a in armas)
                {
                    if (pedido.Armas == null) pedido.Armas = new List<Arma> { a };
                    else pedido.Armas.Add(a);
                }
            }
        }

        public void gestionarAccesorios(IAccesorioService<Accesorio> accesorioService, Pedidos pedido)
        {
            var accesorios = accesorioService.GetAll().Where(ac => ac.Cod_Pedido == pedido.Cod_Pedido);

            if (accesorios != null)
            {
                foreach(var ac in accesorios)
                {
                    if (pedido.Accesorios == null) pedido.Accesorios = new List<Accesorio> { ac };
                    else pedido.Accesorios.Add(ac);
                }
            }
        }
        public void calcularPrecio(Pedidos pedido, IAccesorioService<Accesorio> accesorioService, IArmaService<Arma> armaService)
        {
            if (pedido.Armas != null)
            {
                pedido.Precio_Total += pedido.Armas.Sum(arma => arma.Precio);
            }
            if (pedido.Accesorios != null)
            {
                pedido.Precio_Total += pedido.Accesorios.Sum(accesorio => accesorio.Precio);
            }

        }

        #endregion
    }
}

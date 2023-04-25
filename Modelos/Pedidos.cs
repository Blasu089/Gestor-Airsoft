using ApiAirsoft.Modelos.Armas;

namespace ApiAirsoft.Modelos
{
    public class Pedidos
    {
        public int Cod_Pedido { get; set; }
        public int Cod_Cliente { get; set; }
        public decimal Precio_Total { get; set; }
        public virtual ICollection<Arma>? Armas { get; set; }
        public virtual ICollection<Accesorio>? Accesorios { get; set; }
    }
}

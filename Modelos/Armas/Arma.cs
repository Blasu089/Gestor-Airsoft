using ApiAirsoft.Util.Enumerados;

namespace ApiAirsoft.Modelos.Armas
{
    public class Arma
    {
        public int Cod_Referencia { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Marca { get; set; }
        public string Material { get; set; }
        public bool HopUp { get; set; }
        public int Longitud { get; set; }
        public decimal Peso { get; set; }
        public decimal Potencia { get; set; }
        public int Velocidad { get; set; }
        public int Capacidad_Cargador { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public TipoArma TipoArma { get; set; }
        public int? Color_Id { get; set; }
        public int? Accion_Id { get; set; }
        public int? Disparo_Id { get; set; }
        public int? Capacidad_Cartucho { get; set; }
        public bool? Cartuchos_Incluidos { get; set; }
        public bool? Bipode_Incluido { get; set; }
        public bool? Mira_Incluida { get; set; }
        public int? Cod_Pedido { get; set; }
    }
}

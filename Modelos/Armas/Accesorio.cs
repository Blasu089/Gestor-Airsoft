using ApiAirsoft.Modelos;

namespace ApiAirsoft.Modelos.Armas
{
    public class Accesorio
    {
        public int Cod_Accesorio { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Marca { get; set; }
        public string Material { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public int? Color_Id { get; set; }
        public int? Cod_Pedido { get; set; }
    }
}
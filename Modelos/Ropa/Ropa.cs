using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api.Modelos.Ropa
{
    public class Ropa
    {
        public int Cod_Ropa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Material { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }

    }
}

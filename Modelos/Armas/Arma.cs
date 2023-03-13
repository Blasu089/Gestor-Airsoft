using ApiAirsoft.Modelos;
using System.Data.SqlTypes;
using System.Numerics;

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
        public virtual ICollection<Color> Colores { get; set; }
        public virtual ICollection<Accesorio> Accesorios { get; set; }
        public virtual ICollection<Disparo> Disparos { get; set; }
        public virtual ICollection<Accion> Acciones { get; set; }

    }
}

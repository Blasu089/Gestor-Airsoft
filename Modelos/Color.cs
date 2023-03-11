using Api.Modelos.Armas;

namespace Api.Modelos
{
    public class Color
    {
        public int Cod_Color { get; set; }
        public string Nombre { get; set; }
        public string Hexadecimal { get; set; }

        public virtual ICollection<Arma> Armas { get; set; }
    }
}

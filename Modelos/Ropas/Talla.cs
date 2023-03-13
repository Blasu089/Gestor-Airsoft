namespace ApiAirsoft.Modelos.Ropas
{
    public class Talla
    {
        public int Cod_Talla { get; set; }
        public int Talla_Europea { get; set; }
        public string Talla_Americana { get; set; }
        public virtual ICollection<Ropa> Ropas { get; set; }
    }
}

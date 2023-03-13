namespace ApiAirsoft.Modelos.Ropas
{
    public class Lentes
    {
        public int Cod_Lentes { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Gafas> Gafas { get; set; }
    }
}

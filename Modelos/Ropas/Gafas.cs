namespace ApiAirsoft.Modelos.Ropas
{
    public class Gafas : Ropa
    {
        public virtual ICollection<Lentes> Lentes { get; set; }
    }
}

namespace ApiAirsoft.Modelos.Armas
{
    public class Disparo
    {
        public int Cod_Disparo { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Arma>? Armas { get; set; }
    }
}

namespace ApiAirsoft.Modelos.Armas
{
    public class Accion
    {
        public int Cod_Accion { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Arma>? Armas { get; set; }
    }
}

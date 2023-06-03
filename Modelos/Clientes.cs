namespace ApiAirsoft.Modelos
{
    public class Clientes
    {
        public int Cod_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public ICollection<Pedidos>? Pedidos { get; set; }
    }
}

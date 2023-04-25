namespace ApiAirsoft.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nom_Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }
}

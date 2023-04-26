using ApiAirsoft.Util.Enumerados;

namespace ApiAirsoft.Modelos
{
    public class Usuario
    {
        public int Cod_Usuario { get; set; }
        public string Nom_Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Rol { get; set; }
    }
}

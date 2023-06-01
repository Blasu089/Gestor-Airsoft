using ApiAirsoft.Modelos;
using ApiAirsoft.Util.Enumerados;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiAirsoft.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService<Usuario> service;

        public UsuarioController(IUsuarioService<Usuario> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Usuario>?> GetAll()
        {
            var usuarios = service.GetAll();
            return usuarios.IsNullOrEmpty() ? NotFound() : Ok(usuarios);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Usuario> Get([FromRoute] int id)
        {
            var usuario = service.GetById(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost("crear")]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            var response = service.Post(usuario);
            return response == false ? BadRequest() : Ok(usuario);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Usuario usuario)
        {
            usuario.Cod_Usuario = id;
            var response = service.Put(usuario);
            return response == false ? BadRequest() : Ok(usuario);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Usuario usuario)
        {
            var response = service.Delete(usuario);
            return response == false ? BadRequest() : NoContent();
        }
    }
}

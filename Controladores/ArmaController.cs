using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiAirsoft.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmaController : ControllerBase
    {
        private readonly IArmaService<Arma> service;

        public ArmaController(IArmaService<Arma> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Arma>?> GetAll()
        {
            var armas = service.GetAll();
            return armas.IsNullOrEmpty() ? NotFound() : Ok(armas);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Arma> Get([FromRoute] int id)
        {
            var arma = service.GetById(id);
            return arma == null ? NotFound() : Ok(arma);
        }

        [HttpPost("crear")]
        public ActionResult<Arma> Post([FromBody] Arma arma)
        {
            var response = service.Post(arma);
            return response == false ? BadRequest() : Ok(arma);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Arma arma)
        {
            arma.Cod_Referencia = id;
            var response = service.Put(arma);
            return response == false ? BadRequest() : Ok(arma);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Arma arma)
        {
            var response = service.Delete(arma);
            return response == false ? BadRequest() : NoContent();
        }
    }
}
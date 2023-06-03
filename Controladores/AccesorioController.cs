using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiAirsoft.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesorioController : ControllerBase
    {
        private readonly IAccesorioService<Accesorio> service;

        public AccesorioController(IAccesorioService<Accesorio> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Accesorio>> GetAll()
        {
            var accesorio = service.GetAll();
            return accesorio.IsNullOrEmpty() ? NotFound() : Ok(accesorio);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Accesorio> Get([FromRoute] int id)
        {
            var accesorio = service.GetById(id);
            return accesorio == null ? NotFound() : Ok(accesorio);
        }

        [HttpPost("crear")]
        public ActionResult<Accesorio> Create(Accesorio accesorio)
        {
            var response=service.Post(accesorio);
            return response == false ? BadRequest() : Ok(accesorio);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Accesorio accesorio)
        {
            accesorio.Cod_Accesorio = id;
            var response = service.Put(accesorio);
            return response == false ? BadRequest() : Ok(accesorio);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Accesorio accesorio)
        {
            var response = service.Delete(accesorio);
            return response == false ? BadRequest() : NoContent();
        }
    }
}

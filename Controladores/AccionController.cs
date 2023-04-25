using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ApiAirsoft.Controladores
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccionController : ControllerBase
    {
        private readonly IAccionService<Accion> service;

        public AccionController(IAccionService<Accion> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Accion>> GetAll() 
        {
            var accion = service.GetAll();
            return accion.IsNullOrEmpty() ? NotFound() : Ok(accion);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Accion> Get([FromRoute] int id)
        {
            var accion = service.GetById(id);
            return accion == null ? NotFound() : Ok(accion);
        }

        [HttpPost("crear")]
        public ActionResult<Accion> Create(Accion accion)
        {
            var response = service.Post(accion);
            return response == false ? BadRequest() : Ok(accion);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Accion accion)
        {
            accion.Cod_Accion = id;
            var response = service.Put(accion);
            return response == false ? BadRequest() : Ok(accion);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Accion accion)
        {
            var response = service.Delete(accion);
            return response == false ? BadRequest() : NoContent();
        }
    }
}
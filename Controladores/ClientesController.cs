using ApiAirsoft.Modelos;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ApiAirsoft.Controladores
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteService<Clientes> service;

        public ClientesController(IClienteService<Clientes> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Clientes>> GetAll()
        {
            var clientes = service.GetAll();
            return clientes.IsNullOrEmpty() ? NotFound() : Ok(clientes);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Clientes> Get([FromRoute] int id)
        {
            var clientes = service.GetById(id);
            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpPost("crear")]
        public ActionResult<Clientes> Create(Clientes clientes)
        {
            var response = service.Post(clientes);
            return response == false ? BadRequest() : Ok(clientes);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Clientes clientes)
        {
            clientes.Cod_Cliente = id;
            var response = service.Put(clientes);
            return response == false ? BadRequest() : Ok(clientes);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Clientes clientes)
        {
            var response = service.Delete(clientes);
            return response == false ? BadRequest() : NoContent();
        }
    }
}
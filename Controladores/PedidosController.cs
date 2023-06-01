using ApiAirsoft.Modelos;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiAirsoft.Controladores
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidosService<Pedidos> service;

        public PedidosController(IPedidosService<Pedidos> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Pedidos>> GetAll()
        {
            var pedidos = service.GetAll();
            return pedidos.IsNullOrEmpty() ? NotFound() : Ok(pedidos);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Pedidos> Get([FromRoute] int id)
        {
            var pedidos = service.GetById(id);
            return pedidos == null ? NotFound() : Ok(pedidos);
        }

        [HttpPost("crear")]
        public ActionResult<Pedidos> Create(Pedidos pedidos)
        {
            var response = service.Post(pedidos);
            return response == false ? BadRequest() : Ok(pedidos);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Pedidos pedidos)
        {
            pedidos.Cod_Pedido = id;
            var response = service.Put(pedidos);
            return response == false ? BadRequest() : Ok(pedidos);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Pedidos pedidos)
        {
            var response = service.Delete(pedidos);
            return response == false ? BadRequest() : NoContent();
        }
    }
}
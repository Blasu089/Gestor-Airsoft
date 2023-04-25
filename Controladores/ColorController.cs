using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Servicios.IServices;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiAirsoft.Controladores
{

    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService<Color> service;

        public ColorController(IColorService<Color> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Color>> GetAll()
        {
            var color = service.GetAll();
            return color.IsNullOrEmpty() ? NotFound() : Ok(color);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Color> Get([FromRoute] int id)
        {
            var color = service.GetById(id);
            return color == null ? NotFound() : Ok(color);
        }

        [HttpPost("crear")]
        public ActionResult<Color> Create(Color color)
        {
            var response = service.Post(color);
            return response == false ? BadRequest() : Ok(color);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Color color)
        {
            color.Cod_Color = id;
            var response = service.Put(color);
            return response == false ? BadRequest() : Ok(color);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Color color) 
        {
            var response = service.Delete(color);
            return response == false ? BadRequest() : NoContent();
        }
    }
}

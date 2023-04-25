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
    public class DisparoController : ControllerBase
    {
        private readonly IDisparoService<Disparo> service;

        public DisparoController(IDisparoService<Disparo> service)
        {
            this.service = service;
        }

        [HttpGet("mostrar")]
        public ActionResult<ICollection<Disparo>> GetAll()
        {
            var disparo = service.GetAll();
            return disparo.IsNullOrEmpty() ? NotFound() : Ok(disparo);
        }

        [HttpGet("mostrar/{id}")]
        public ActionResult<Disparo> Get([FromRoute] int id)
        {
            var disparo = service.GetById(id);
            return disparo == null ? NotFound() : Ok(disparo);
        }

        [HttpPost("crear")]
        public ActionResult<Disparo> Create(Disparo disparo)
        {
            var response = service.Post(disparo);
            return response == false ? BadRequest() : Ok(disparo);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Disparo disparo)
        {
            disparo.Cod_Disparo = id;
            var response = service.Put(disparo);
            return response == false ? BadRequest() : Ok(disparo);
        }

        [HttpDelete("borrar")]
        public IActionResult Delete(Disparo disparo)
        {
            var response = service.Delete(disparo);
            return response == false ? BadRequest() : NoContent();
        }
    }
}
using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        public IPrioridadService _prioridadService;

        private Prioridad Convertir(PrioridadModel prioridadModel) 
        {
            return new Prioridad
            {
                IdPrioridad = prioridadModel.IdPrioridad,
                Descripcion = prioridadModel.Descripcion,
            };
        }

        private PrioridadModel Convertir(Prioridad prioridad)
        {
            return new PrioridadModel
            {
                IdPrioridad = prioridad.IdPrioridad,
                Descripcion = prioridad.Descripcion,
            };
        }

        // GET: api/<PrioridadController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Prioridad> lista = _prioridadService.GetPrioridadesAsync().Result;
            List<PrioridadModel> prioridad = new List<PrioridadModel>();

            foreach (var item in lista)
            {
                prioridad.Add(Convertir(item));
            }
            return Ok(prioridad);
        }

        // GET api/<PrioridadController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            {
                Prioridad prioridad = _prioridadService.GetPrioridades(id);
                PrioridadModel prioridadModel = Convertir(prioridad);
                return Ok(prioridadModel);
            }
        }

        // POST api/<PrioridadController>
        [HttpPost]
        public IActionResult Post([FromBody] PrioridadModel prioridadModel)
        {
            Prioridad entity = Convertir(prioridadModel);
            _prioridadService.AddPrioridad(entity);
            return Ok(Convertir(entity));
        }

        // PUT api/<PrioridadController>/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] PrioridadModel prioridadModel)
        {
            Prioridad entity = Convertir(prioridadModel);
            _prioridadService.UpdatePrioridad(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<PrioridadController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Prioridad prioridad = new Prioridad
            {
                IdPrioridad = id
            };

            _prioridadService.DeletePrioridad(prioridad);
            return Ok();

        }
    }
}

using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        public IEstadosService _estadosService;

        private Estado Convertir(EstadosModel estadoModel)
        {
            return new Estado
            {
                IdEstado = estadoModel.IdEstado ,
                Descripcion = estadoModel.Descripcion,
            };
        }

        private EstadosModel Convertir(Estado estado)
        {
            return new EstadosModel
            {
                IdEstado = estado.IdEstado,
                Descripcion = estado.Descripcion,
            };
        }

        public EstadosController(IEstadosService estadoService)
        {
            _estadosService = estadoService;
        }

        // GET: api/<EstadosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Estado> lista = _estadosService.GetEstadosAsync().Result;
            List<EstadosModel> estados = new List<EstadosModel>();

            foreach (var item in lista)
            {
                estados.Add(Convertir(item));
            }
            return Ok(estados);
        }

        // GET api/<EstadosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Estado estado = _estadosService.GetEstados(id);
            EstadosModel estadosModel = Convertir(estado);
            return Ok(estadosModel);
        }

        // POST api/<EstadosController>
        [HttpPost]
        public IActionResult Post([FromBody] EstadosModel estadosModel)
        {
            Estado entity = Convertir(estadosModel);
            _estadosService.AddEstado(entity);
            return Ok(Convertir(entity));
        }

        // PUT api/<EstadosController>/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] EstadosModel estadosModel)
        {
            Estado entity = Convertir(estadosModel);
            _estadosService.UpdateEstado(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<EstadosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Estado estado = new Estado
            {
                IdEstado = id
            };

            _estadosService.DeleteEstado(estado);
            return Ok();
        }
    }
}

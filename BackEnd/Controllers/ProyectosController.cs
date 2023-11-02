using BackEnd.Models;
using Entities.Entities;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        ProyectosModel Convertir (Proyecto proyectos)
        {
            return new ProyectosModel
            {
                IdProyecto = proyectos.IdProyecto,
                NombreProyecto = proyectos.NombreProyecto,
                DescripcionProyecto = proyectos.DescripcionProyecto,
                FechaIncio = proyectos.FechaIncio,
                FechaFinalizacion = proyectos.FechaFinalizacion,
                IdUsuario = proyectos.IdUsuario,
                IdEstado = proyectos.IdEstado,
            };
        }

        Proyecto Convertir(ProyectosModel proyectos)
        {
            return new Proyecto
            {
                IdProyecto = proyectos.IdProyecto,
                NombreProyecto = proyectos.NombreProyecto,
                DescripcionProyecto = proyectos.DescripcionProyecto,
                FechaIncio = proyectos.FechaIncio,
                FechaFinalizacion = proyectos.FechaFinalizacion,
                IdUsuario = proyectos.IdUsuario,
                IdEstado = proyectos.IdEstado,
            };
        }

        public IProyectosService _proyectosService;

        public ProyectosController(IProyectosService proyectosService)
        {
            _proyectosService = proyectosService;
        }



        // GET: api/<ProyectosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Proyecto> proyectos = await _proyectosService.GetProyectos();
            List<ProyectosModel> proyectosModel = new List<ProyectosModel>();

            foreach (var item in proyectos)
            {
                proyectosModel.Add(this.Convertir(item));
            }


            return Ok(proyectosModel);
        }

        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           Proyecto proyecto = await _proyectosService.GetById(id);
            return Ok(Convertir(proyecto));
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProyectosModel proyectosModel)
        {
            Proyecto proyecto = Convertir(proyectosModel);
            _proyectosService.AddProyecto(proyecto);
            return Ok(Convertir(proyecto));
        }

        // PUT api/<ProyectosController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProyectosModel proyectosModel)
        {
            Proyecto proyecto = Convertir(proyectosModel);
            _proyectosService.UpdateProyecto(proyecto);
            return Ok(Convertir(proyecto));
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _proyectosService.DeleteProyecto(id);
        }
    }
}

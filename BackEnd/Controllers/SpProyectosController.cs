using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using Entities.Entities;
using BackEnd.Services.Interfaces;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpProyectosController : ControllerBase
    {
        SpProyectosModel Convertir (sp_GetAllProyectos_Result spProyectos)
        {
            return new SpProyectosModel
            {
                IdProyecto = spProyectos.IdProyecto,
                NombreProyecto = spProyectos.NombreProyecto,
                DescripcionProyecto = spProyectos.DescripcionProyecto,
                FechaIncio = spProyectos.FechaIncio,
                FechaFinalizacion = spProyectos.FechaFinalizacion,
                NombreUsaurio = spProyectos.NombreUsaurio,
                Estado = spProyectos.Estado,
            };
        }

         sp_GetAllProyectos_Result Convertir(SpProyectosModel spProyectos)
        {
            return new sp_GetAllProyectos_Result
            {
                IdProyecto = spProyectos.IdProyecto,
                NombreProyecto = spProyectos.NombreProyecto,
                DescripcionProyecto = spProyectos.DescripcionProyecto,
                FechaIncio = spProyectos.FechaIncio,
                FechaFinalizacion = spProyectos.FechaFinalizacion,
                NombreUsaurio = spProyectos.NombreUsaurio,
                Estado = spProyectos.Estado,
            };
        }

        ISpProyectosService _spProyectosService;

        public SpProyectosController(ISpProyectosService spProyectosService)
        {
            _spProyectosService = spProyectosService;
        }



        // GET: api/<SpProyectosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<sp_GetAllProyectos_Result> proyectos = await _spProyectosService.GetProyectos();
            List<SpProyectosModel> spProyectosModels = new List<SpProyectosModel>();

            foreach (var item in proyectos)
            {
                spProyectosModels.Add(Convertir(item));
            }

            return Ok(spProyectosModels);
        }

    }
}

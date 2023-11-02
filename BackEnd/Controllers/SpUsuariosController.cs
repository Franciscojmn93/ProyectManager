using BackEnd.Models;
using Entities.Entities;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpUsuariosController : ControllerBase
    {
        SpUsuariosModel Convertir (sp_GetAllUsuarios_Result spUsarios)
        {
            return new SpUsuariosModel
            {
                IdUsuario = spUsarios.IdUsuario,
                NombreUsaurio = spUsarios.NombreUsaurio,
                NombreDepartamento = spUsarios.NombreDepartamento,
                NombreCargo = spUsarios.NombreCargo,
                NombreRol = spUsarios.NombreRol,
            };
        }

        sp_GetAllUsuarios_Result Convertir(SpUsuariosModel spUsarios)
        {
            return new sp_GetAllUsuarios_Result
            {
                IdUsuario = spUsarios.IdUsuario,
                NombreUsaurio = spUsarios.NombreUsaurio,
                NombreDepartamento = spUsarios.NombreDepartamento,
                NombreCargo = spUsarios.NombreCargo,
                NombreRol = spUsarios.NombreRol,
            };
        }


        ISpUsuariosService _spUsuariosService;

        public SpUsuariosController(ISpUsuariosService usuariosService)
        {
            _spUsuariosService = usuariosService;
        }


        // GET: api/<SpUsuariosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<sp_GetAllUsuarios_Result> usuarios = await _spUsuariosService.GetSpUsuarios();
            List<SpUsuariosModel> spUsuariosModels= new List<SpUsuariosModel>();

            foreach (var item in usuarios)
            {
                spUsuariosModels.Add(Convertir(item));
            }

            return Ok(spUsuariosModels);
        }

    }
}

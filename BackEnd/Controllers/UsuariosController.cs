using BackEnd.Models;
using Entities.Entities;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuariosModel Convertir(Usuario usuario)
        {
            return new UsuariosModel
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsaurio = usuario.NombreUsaurio,
                IdCargo = usuario.IdCargo,
                IdDepartamento = usuario.IdDepartamento,
                Idrol = usuario.Idrol


            };
        }
        Usuario Convertir(UsuariosModel usuario)
        {
            return new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsaurio = usuario.NombreUsaurio,
                IdCargo = usuario.IdCargo,
                IdDepartamento = usuario.IdDepartamento,
                Idrol = usuario.Idrol


            };
        }

        IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }



        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Usuario> usuarios = await _usuariosService.GetUsuarios();
            List<UsuariosModel> usuariosModels = new List<UsuariosModel>();

            foreach (var item in usuarios)
            {
                usuariosModels.Add(this.Convertir(item));
            }


            return Ok(usuariosModels);
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Usuario usuario = _usuariosService.GetById(id);
            UsuariosModel usuarioModel = Convertir(usuario);
            return Ok(usuarioModel);

        }

        [HttpGet("VerificarUsuario")]
        public IActionResult VerificarUsuario(string nombreUsuario)
        {
            bool usuarioExiste = _usuariosService.ExisteUsuario(nombreUsuario);

            if (usuarioExiste)
            {
                return Ok(new { Mensaje = "Usuario encontrado" });
            }

            return NotFound(new { Mensaje = "Usuario no encontrado" });
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuariosModel usuarioModel)
        {
            Usuario usuario = this.Convertir(usuarioModel);

            _usuariosService.Add(usuario);



            return Ok(Convertir(usuario));
        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsuariosModel usuarioModel)
        {
            Usuario usuario = this.Convertir(usuarioModel);

            _usuariosService.Update(usuario);



            return Ok(Convertir(usuario));
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario = id
            };

            _usuariosService.Delete(usuario);
            return Ok();
        }
    }
}

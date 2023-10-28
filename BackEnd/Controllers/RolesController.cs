using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRolService _rolService { get; set; }

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }



        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Role> roles = await _rolService.GetRoles();
            return Ok(roles);
        }

    }
}

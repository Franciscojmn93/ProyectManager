using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        public IDepartamentosService _departamentosService;

        private Departamento Convertir(DepartamentosModel departamentos)
        {
            return new Departamento
            {
              IdDepartamento = departamentos.IdDepartamento,
              NombreDepartamento = departamentos.NombreDepartamento,
              NombreResponsable = departamentos.NombreResponsable
            };
        }

        private DepartamentosModel Convertir(Departamento departamentos)
        {
            return new DepartamentosModel
            {
                IdDepartamento = departamentos.IdDepartamento,
                NombreDepartamento = departamentos.NombreDepartamento,
                NombreResponsable = departamentos.NombreResponsable
            };
        }

        public DepartamentosController(IDepartamentosService departamentosService)
        {
            _departamentosService = departamentosService;
        }



        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Departamento> lista = _departamentosService.GetDepartamentosAsync().Result;
            List<DepartamentosModel> departamentos= new List<DepartamentosModel>();

            foreach (var item in lista) 
            {
                departamentos.Add(Convertir(item));
            }
                return Ok(departamentos);
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Departamento departamento = _departamentosService.GetDepartamento(id);
            DepartamentosModel departamentosModel = Convertir(departamento);
            return Ok(departamentosModel);
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] DepartamentosModel departamentosModel)
        {
            Departamento entity = Convertir(departamentosModel);
            _departamentosService.AddDepartamento(entity);
            return Ok(Convertir(entity));
        }

        // PUT api/<DepartamentosController>/5 //AQUI hay que quitar esto ("{id}")//
        [HttpPut]
        public IActionResult Put([FromBody] DepartamentosModel departamentosModel)
        {
            Departamento entity = Convertir(departamentosModel);
            _departamentosService.UpdateDepartamento(entity);
            return Ok(Convertir(entity));

        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = id
            };

            _departamentosService.DeleteDepartamento(departamento);
            return Ok();
        }
    }
}

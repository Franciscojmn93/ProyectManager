using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;



namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public ICargosService _cargosService;

        private Cargo Convertir(CargoModel cargoModel)
        {
            return new Cargo
            {
                IdCargo = cargoModel.IdCargo,
                NombreCargo = cargoModel.NombreCargo,
            };
        }

        private CargoModel Convertir(Cargo cargo) 
        {
            return new CargoModel
            {
                IdCargo = cargo.IdCargo,
                NombreCargo = cargo.NombreCargo,
            };
        }

        public CargoController(ICargosService cargosService)
        {
            _cargosService= cargosService;
        }
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cargo> lista = _cargosService.GetCargosAsync().Result;
            List<CargoModel> cargos = new List<CargoModel>();

            foreach (var item in lista)
            {
                cargos.Add(Convertir(item));
            }
            return Ok(cargos);
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cargo cargo = _cargosService.GetCargo(id);
            CargoModel cargosModel = Convertir(cargo);
            return Ok(cargosModel);
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] CargoModel cargosModel)
        {
            Cargo entity = Convertir(cargosModel);
            _cargosService.AddCargo(entity);
            return Ok(Convertir(entity));
        }

        // PUT api/<DepartamentosController>/5 //AQUI hay que quitar esto ("{id}")//
        [HttpPut]
        public IActionResult Put([FromBody] CargoModel cargosModel)
        {
            Cargo entity = Convertir(cargosModel);
            _cargosService.UpdateCargo(entity);
            return Ok(Convertir(entity));

        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Cargo cargo = new Cargo
            {
                IdCargo = id
            };

            _cargosService.DeleteCargo(cargo);
            return Ok();
        }
    }
}

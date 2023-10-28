using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using System.Runtime.InteropServices;

namespace BackEnd.Services.Implementations
{
    public class CargosService : ICargosService
    {
        public IUnidadeDeTrabajo _unidadDeTrabajo;

        public CargosService(IUnidadeDeTrabajo cargosService) 
        {
            _unidadDeTrabajo = cargosService;
        }

        public bool AddCargo(Cargo cargo)
        {
            bool resultado = _unidadDeTrabajo._cargosDAL.Add(cargo);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteCargo(Cargo cargo)
        {
            bool resultado = _unidadDeTrabajo._cargosDAL.Remove(cargo);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Cargo GetCargo(int id)
        {
            Cargo cargo;
            cargo = _unidadDeTrabajo._cargosDAL.Get(id);
            return cargo;
        }

        public async Task<IEnumerable<Cargo>> GetCargosAsync()
        {
            IEnumerable<Cargo> cargo;
            cargo = await _unidadDeTrabajo._cargosDAL.GetAll();
            return cargo;
        }

        public bool UpdateCargo(Cargo cargo)
        {
            bool resultado = _unidadDeTrabajo._cargosDAL.Update(cargo);
            _unidadDeTrabajo.Complete();
            return resultado;
        }
    }
}

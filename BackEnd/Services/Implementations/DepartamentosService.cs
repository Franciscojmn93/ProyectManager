using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using System.Runtime.InteropServices;

namespace BackEnd.Services.Implementations
{
    public class DepartamentosService : IDepartamentosService
    {
        public IUnidadeDeTrabajo _unidadDeTrabajo;

        public DepartamentosService(IUnidadeDeTrabajo unidadeDeTrabajo)
        {
           _unidadDeTrabajo= unidadeDeTrabajo;
        }

        public bool AddDepartamento(Departamento departamento)
        {
            bool resultado = _unidadDeTrabajo._departamentoDAL.Add(departamento);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteDepartamento(Departamento departamento)
        {
            bool resultado = _unidadDeTrabajo._departamentoDAL.Remove(departamento);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Departamento GetDepartamento(int id)
        {
            Departamento departamento;
            departamento = _unidadDeTrabajo._departamentoDAL.Get(id);
            return departamento;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosAsync()
        {
            IEnumerable<Departamento> departamentos;
            departamentos = await _unidadDeTrabajo._departamentoDAL.GetAll();
            return departamentos;
        }

        public bool UpdateDepartamento(Departamento departamento)
        {
            bool resultado = _unidadDeTrabajo._departamentoDAL.Update(departamento);
            _unidadDeTrabajo.Complete(); 
            return resultado;                                                  
        }
    }
}

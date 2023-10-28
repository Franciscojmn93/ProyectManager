using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using System.Runtime.InteropServices;

namespace BackEnd.Services.Implementations
{
    public class EstadosService : IEstadosService
    {
        public IUnidadeDeTrabajo _unidadDeTrabajo;

        public EstadosService(IUnidadeDeTrabajo estadosService)
        {
            _unidadDeTrabajo = estadosService;
        }

        public bool AddEstado(Estado estado)
        {
            bool resultado = _unidadDeTrabajo._estadosDAL.Add(estado);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeleteEstado(Estado estado)
        {
            bool resultado = _unidadDeTrabajo._estadosDAL.Remove(estado);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Estado GetEstados(int id)
        {
            Estado estado;
            estado = _unidadDeTrabajo._estadosDAL.Get(id);
            return estado;
        }

        public async Task<IEnumerable<Estado>> GetEstadosAsync()
        {
            IEnumerable<Estado> estado;
            estado = await _unidadDeTrabajo._estadosDAL.GetAll();
            return estado;
        }

        public bool UpdateEstado(Estado estado)
        {
            bool resultado = _unidadDeTrabajo._estadosDAL.Update(estado);
            _unidadDeTrabajo.Complete();
            return resultado;
        }
    }
}

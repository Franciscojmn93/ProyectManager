using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PrioridadService : IPrioridadService
    {
        public IUnidadeDeTrabajo _unidadDeTrabajo;

        public PrioridadService(IUnidadeDeTrabajo prioridadService)
        {
            _unidadDeTrabajo = prioridadService;
        }
        
        public bool AddPrioridad(Prioridad prioridad)
        {
            bool resultado = _unidadDeTrabajo._prioridadDAL.Add(prioridad);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public bool DeletePrioridad(Prioridad prioridad)
        {
            bool resultado = _unidadDeTrabajo._prioridadDAL.Remove(prioridad);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Prioridad GetPrioridades(int id)
        {
            Prioridad prioridad;
            prioridad = _unidadDeTrabajo._prioridadDAL.Get(id);
            return prioridad;
        }

        public async Task<IEnumerable<Prioridad>> GetPrioridadesAsync()
        {
            IEnumerable<Prioridad> prioridad;
            prioridad = await _unidadDeTrabajo._prioridadDAL.GetAll();
            return prioridad;
        }

        public bool UpdatePrioridad(Prioridad prioridad)
        {
            bool resultado = _unidadDeTrabajo._prioridadDAL.Update(prioridad);
            _unidadDeTrabajo.Complete();
            return resultado;
        }
    }
}

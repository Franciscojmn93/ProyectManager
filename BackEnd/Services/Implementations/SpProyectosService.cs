using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SpProyectosService : ISpProyectosService   
    {
        IUnidadeDeTrabajo _unidadDeTrabajo;

        public SpProyectosService(IUnidadeDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<IEnumerable<sp_GetAllProyectos_Result>> GetProyectos()
        {
            IEnumerable<sp_GetAllProyectos_Result> proyectos =
                await _unidadDeTrabajo._spProyectosDAL.GetAll();
            return proyectos;
        }
    }
}

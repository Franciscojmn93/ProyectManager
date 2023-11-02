using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SpUsuariosService : ISpUsuariosService
    {
        IUnidadeDeTrabajo _unidadDeTrabajo;

        public SpUsuariosService(IUnidadeDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<IEnumerable<sp_GetAllUsuarios_Result>> GetSpUsuarios()
        {
            IEnumerable<sp_GetAllUsuarios_Result> usuarios =
                await _unidadDeTrabajo._spUsuariosDAL.GetAll();
            return usuarios;
        }
    }
}

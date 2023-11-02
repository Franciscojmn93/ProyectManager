using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISpUsuariosService
    {
        Task<IEnumerable<sp_GetAllUsuarios_Result>> GetSpUsuarios();

    }
}

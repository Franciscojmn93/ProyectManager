using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISpProyectosService
    {
        Task<IEnumerable<sp_GetAllProyectos_Result>> GetProyectos();

    }
}

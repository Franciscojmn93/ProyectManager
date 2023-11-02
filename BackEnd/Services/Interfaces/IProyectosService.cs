using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IProyectosService
    {
        Task<IEnumerable<Proyecto>> GetProyectos();
        Task<bool> AddProyecto(Proyecto usuario);
        Task<bool> UpdateProyecto(Proyecto usuario);
        Task<bool> DeleteProyecto(int id);
        Task<Proyecto> GetById(int id);
    }
}

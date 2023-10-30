using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IEstadosService
    {
        Task<IEnumerable<Estado>> GetEstadosAsync();

        Estado GetEstados(int id);
        bool AddEstado(Estado estado);
        bool UpdateEstado(Estado estado);
        bool DeleteEstado(Estado estado);
    }
}

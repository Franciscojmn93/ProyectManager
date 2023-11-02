using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrioridadService
    {
        Task<IEnumerable<Prioridad>> GetPrioridadesAsync();

        Prioridad GetPrioridades(int id);
        bool AddPrioridad(Prioridad prioridad);
        bool UpdatePrioridad(Prioridad prioridad);
        bool DeletePrioridad(Prioridad prioridad);
    }
}

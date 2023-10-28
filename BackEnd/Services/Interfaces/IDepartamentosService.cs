using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IDepartamentosService
    {
        Task<IEnumerable<Departamento>> GetDepartamentosAsync();

        Departamento GetDepartamento(int id);
        bool AddDepartamento(Departamento departamento);
        bool UpdateDepartamento(Departamento departamento);
        bool DeleteDepartamento(Departamento departamento);
    }
}

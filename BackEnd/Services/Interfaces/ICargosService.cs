using Entities.Entities;
namespace BackEnd.Services.Interfaces
{
    public interface ICargosService
    {
        Task<IEnumerable<Cargo>> GetCargosAsync();

        Cargo GetCargo(int id);
        bool AddCargo(Cargo Cargo);
        bool UpdateCargo(Cargo Cargo);
        bool DeleteCargo(Cargo Cargo);
    }
}

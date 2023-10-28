using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Role>> GetRoles();
        Role GetById(int id);
        bool AddRol(Role role);
        bool UpdateRol(Role role);
        bool DeteleRol(Role role);
    }   
}

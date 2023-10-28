using Entities.Entities;
namespace BackEnd.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<bool> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(int id);
        Task<Usuario> GetById(int id);
    }
}

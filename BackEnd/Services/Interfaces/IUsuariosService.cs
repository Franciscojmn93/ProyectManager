using Entities.Entities;
namespace BackEnd.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();

        Usuario GetById(int id);
        bool Add(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(Usuario usuario);
    }
}

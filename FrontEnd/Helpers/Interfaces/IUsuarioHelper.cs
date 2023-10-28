using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {
        List<UsuarioViewModel> GetUsuarios();
        UsuarioViewModel GetById(int id);
        UsuarioViewModel AddUsuario(UsuarioViewModel usuario);
        UsuarioViewModel EditUsuario(UsuarioViewModel usaurio);

        void DeleteUsuario(int id);
    }
}

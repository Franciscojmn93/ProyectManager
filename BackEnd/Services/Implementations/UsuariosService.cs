using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuariosService : IUsuariosService
    {
        IUnidadeDeTrabajo _unidadDeTrabajo;

        public UsuariosService(IUnidadeDeTrabajo unidadeDeTrabajo) 
        {
            _unidadDeTrabajo= unidadeDeTrabajo;
        }

        public bool Add(Usuario usuario)
        {
             bool resultado =   _unidadDeTrabajo._usuariosDAL.Add(usuario);
                _unidadDeTrabajo.Complete();
                return resultado;
        }

        public bool Delete(Usuario usuario)
        {

              bool resultado =  _unidadDeTrabajo._usuariosDAL.Remove(usuario);
                _unidadDeTrabajo.Complete();
                return resultado;

        }


        public Usuario GetById(int id)
        {
            Usuario usuario;
            usuario =  _unidadDeTrabajo._usuariosDAL.Get(id);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = await _unidadDeTrabajo._usuariosDAL.GetAll();
            return usuarios;
        }

        public bool Update(Usuario usuario)
        {

              bool resultado = _unidadDeTrabajo._usuariosDAL.Update(usuario);
                _unidadDeTrabajo.Complete();
            return resultado; 

        }
    }
}

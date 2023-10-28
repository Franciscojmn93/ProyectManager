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

        public Task<bool> Add(Usuario usuario)
        {
            try
            {
                _unidadDeTrabajo._usuariosDAL.Add(usuario);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception) 
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                Usuario usuario = new Usuario { IdUsuario = id };
                _unidadDeTrabajo._usuariosDAL.Remove(usuario);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario =  _unidadDeTrabajo._usuariosDAL.Get(id);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios = await _unidadDeTrabajo._usuariosDAL.GetAll();
            return usuarios;
        }

        public Task<bool> Update(Usuario usuario)
        {
            try
            {
                _unidadDeTrabajo._usuariosDAL.Update(usuario);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
    }
}

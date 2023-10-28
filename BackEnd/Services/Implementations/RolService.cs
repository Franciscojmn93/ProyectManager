using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RolService : IRolService
    {
        public IUnidadeDeTrabajo _unidadDeTrabajo;

        public RolService(IUnidadeDeTrabajo unidadeDeTrabajo) 
        {
            _unidadDeTrabajo= unidadeDeTrabajo;
        }

        public bool AddRol(Role role)
        {
            bool resultado = _unidadDeTrabajo._rolDAL.Add(role);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public bool DeteleRol(Role role)
        {
            bool resultado = _unidadDeTrabajo._rolDAL.Remove(role);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Role GetById(int id)
        {
            Role role;
            role = _unidadDeTrabajo._rolDAL.Get(id);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            IEnumerable<Role> role;
            role = await _unidadDeTrabajo._rolDAL.GetAll();
            return role;
        }

        public bool UpdateRol(Role role)
        {
            bool resultado = _unidadDeTrabajo._rolDAL.Update(role);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}

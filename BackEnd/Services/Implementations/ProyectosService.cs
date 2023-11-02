using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProyectosService : IProyectosService
    {
        IUnidadeDeTrabajo _unidadDeTrabajo;

        public ProyectosService(IUnidadeDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Task<bool> AddProyecto(Proyecto proyecto)
        {
            try
            {
                _unidadDeTrabajo._proyectosDAL.Add(proyecto);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteProyecto(int id)
        {
            try
            {
                Proyecto proyecto = new Proyecto { IdProyecto= id };
                _unidadDeTrabajo._proyectosDAL.Remove(proyecto);
                _unidadDeTrabajo.Complete(); 
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }

        public async Task<Proyecto> GetById(int id)
        {
            Proyecto proyecto = _unidadDeTrabajo._proyectosDAL.Get(id);
            return proyecto;
        }

        public async Task<IEnumerable<Proyecto>> GetProyectos()
        {
            IEnumerable<Proyecto> proyectos = await _unidadDeTrabajo._proyectosDAL.GetAll();
            return proyectos;
        }

        public Task<bool> UpdateProyecto(Proyecto proyecto)
        {
            try
            {
                _unidadDeTrabajo._proyectosDAL.Update(proyecto);
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

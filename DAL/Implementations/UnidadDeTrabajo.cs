using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadeDeTrabajo
    {
        public IDepartamentoDAL _departamentoDAL { get; }
        public ICargosDAL _cargosDAL { get; }

        public IUsuariosDAL _usuariosDAL { get; }

        public IRolDAL _rolDAL { get; }

        public IEstadosDAL _estadosDAL { get; }

        private readonly ProyectManagerContext _context;
       
        public UnidadDeTrabajo(ProyectManagerContext context,
                            IDepartamentoDAL departamentoDAL,
                            ICargosDAL cargosDAL,
                            IUsuariosDAL usuariosDAL,
                            IRolDAL oldrDAL,
                            IEstadosDAL estadosDAL)
        {
            _context = context;
            _departamentoDAL = departamentoDAL;
            _cargosDAL = cargosDAL;
            _usuariosDAL = usuariosDAL;
            _rolDAL = oldrDAL;
            _estadosDAL = estadosDAL;
        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

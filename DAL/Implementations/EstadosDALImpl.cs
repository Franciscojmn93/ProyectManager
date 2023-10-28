using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EstadosDALImpl : DALGenericoImpl<Estado>, IEstadosDAL
    {
        public EstadosDALImpl (ProyectManagerContext context) : base(context)
        {

        }
    }
}

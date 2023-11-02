using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public  class UsuariosDALImpl : DALGenericoImpl<Usuario>, IUsuariosDAL
    {
      
        public UsuariosDALImpl(ProyectManagerContext context) : base (context) 
        {
            
        }

    }
}

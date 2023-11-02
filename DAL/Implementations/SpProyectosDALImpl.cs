using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SpProyectosDALImpl : DALGenericoImpl<sp_GetAllProyectos_Result>, ISpProyectosDAL
    {
        ProyectManagerContext _context;


        public SpProyectosDALImpl(ProyectManagerContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<sp_GetAllProyectos_Result>> GetAll()
        {
            List<sp_GetAllProyectos_Result> proyectos = new List<sp_GetAllProyectos_Result>();
            List<sp_GetAllProyectos_Result> results;
            string sql = "[dbo].[indexProyectos]";

            results = await _context.Sp_IndexProyectos.FromSqlRaw(sql)
                .ToListAsync();
            foreach (var item in results)
            {
                proyectos.Add(
                    new sp_GetAllProyectos_Result
                    {
                       IdProyecto = item.IdProyecto,
                       NombreProyecto = item.NombreProyecto,
                       DescripcionProyecto= item.DescripcionProyecto,
                       FechaIncio= item.FechaIncio,
                       FechaFinalizacion= item.FechaFinalizacion,
                       NombreUsaurio= item.NombreUsaurio,
                       Estado= item.Estado,

                    }
                    );
            }
            return proyectos;
        }
}
}


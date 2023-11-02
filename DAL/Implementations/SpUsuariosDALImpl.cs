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
    public  class SpUsuariosDALImpl : DALGenericoImpl<sp_GetAllUsuarios_Result>, ISpUsuariosDAL
    {
        ProyectManagerContext _context;

        public SpUsuariosDALImpl(ProyectManagerContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<sp_GetAllUsuarios_Result>> GetAll()
        {
            List<sp_GetAllUsuarios_Result> usuarios = new List<sp_GetAllUsuarios_Result>();
            List<sp_GetAllUsuarios_Result> results;
            string sql = "[dbo].[indexUsuarios]";

            results = await _context.Sp_IndexUsuarios.FromSqlRaw(sql)
                .ToListAsync();
            foreach (var item in results)
            {
                usuarios.Add(
                    new sp_GetAllUsuarios_Result
                    {
                        IdUsuario = item.IdUsuario,
                        NombreUsaurio = item.NombreUsaurio,
                        NombreCargo = item.NombreCargo,
                        NombreDepartamento = item.NombreDepartamento,
                        NombreRol = item.NombreRol

                    }
                    );
            }
            return usuarios;
        }
    }
}

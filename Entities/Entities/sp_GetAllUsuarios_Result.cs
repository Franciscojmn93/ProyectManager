using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Keyless]
    public class sp_GetAllUsuarios_Result
    {
        public int IdUsuario { get; set; }
        public string NombreUsaurio { get; set; }
        public string NombreCargo { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombreRol { get; set; }
    }
}

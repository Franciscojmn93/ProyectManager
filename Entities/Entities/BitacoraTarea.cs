using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class BitacoraTarea
    {
        public int IdEntrada { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public DateTime FechaEntrada { get; set; }
        public int IdTarea { get; set; }
        public string Operacionrealizada { get; set; } = null!;

        public virtual Tarea IdTareaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}

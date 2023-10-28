using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string DescripcionProyecto { get; set; } = null!;
        public DateTime? FechaIncio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}

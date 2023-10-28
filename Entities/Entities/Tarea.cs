using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Tarea
    {
        public Tarea()
        {
            BitacoraTareas = new HashSet<BitacoraTarea>();
        }

        public int Idtarea { get; set; }
        public string TituloTarea { get; set; } = null!;
        public string DescripcionTarea { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdPrioridad { get; set; }
        public int IdEstado { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProyecto { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Prioridad IdPrioridadNavigation { get; set; } = null!;
        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<BitacoraTarea> BitacoraTareas { get; set; }
    }
}

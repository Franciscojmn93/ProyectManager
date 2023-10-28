using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            BitacoraTareas = new HashSet<BitacoraTarea>();
            Proyectos = new HashSet<Proyecto>();
            Tareas = new HashSet<Tarea>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsaurio { get; set; } = null!;
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public int Idrol { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; } = null!;
        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Role IdrolNavigation { get; set; } = null!;
        public virtual ICollection<BitacoraTarea> BitacoraTareas { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}

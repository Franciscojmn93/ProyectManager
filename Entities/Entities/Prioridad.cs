using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Prioridad
    {
        public Prioridad()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdPrioridad { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}

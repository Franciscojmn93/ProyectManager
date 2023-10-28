using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Departamento
    {
        public Departamento()
        {
            Tareas = new HashSet<Tarea>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; } = null!;
        public string NombreResponsable { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCargo { get; set; }
        public string NombreCargo { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

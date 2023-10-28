using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class IntentosLogin
    {
        public int IdRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreUsaurio { get; set; } = null!;
        public string DireccionIp { get; set; } = null!;
        public string Navegador { get; set; } = null!;
    }
}

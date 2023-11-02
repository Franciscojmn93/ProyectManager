namespace FrontEnd.Models
{
    public class ProyectosViewModel
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string DescripcionProyecto { get; set; } = null!;
        public DateTime? FechaIncio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }

        public IEnumerable<UsuarioViewModel> usuarios { get; set; }
        public IEnumerable<EstadosViewModel> estados { get; set; }




        // /api/Proyectos/ //
    }
}

namespace BackEnd.Models
{
    public class ProyectosModel
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string DescripcionProyecto { get; set; } = null!;
        public DateTime? FechaIncio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }




        // /api/Proyectos/ //
    }
}

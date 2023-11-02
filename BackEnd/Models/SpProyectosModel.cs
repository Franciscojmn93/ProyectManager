namespace BackEnd.Models
{
    public class SpProyectosModel
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string NombreUsaurio { get; set; }
        public string Estado { get; set; }
    }
}

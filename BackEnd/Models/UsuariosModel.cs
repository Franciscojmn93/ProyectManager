namespace BackEnd.Models
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsaurio { get; set; } = null!;
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public int Idrol { get; set; }
    }
}

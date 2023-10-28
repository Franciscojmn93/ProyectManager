namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsaurio { get; set; } = null!;
        public int IdCargo { get; set; }

        public IEnumerable<CargosViewModel> Cargos { get; set; }
        public int IdDepartamento { get; set; }
        public IEnumerable<DepartamentosViewModel> Departamentos { get; set; }
        public int Idrol { get; set; }

        public IEnumerable<RolViewModelcs> roles { get; set; }

    }
}

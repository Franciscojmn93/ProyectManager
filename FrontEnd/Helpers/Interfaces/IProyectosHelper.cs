using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProyectosHelper
    {
        List<ProyectosViewModel> GetProyectos();
        ProyectosViewModel GetById(int id);
        ProyectosViewModel AddProyecto(ProyectosViewModel usuario);
        ProyectosViewModel EditProyecto(ProyectosViewModel usaurio);

        void DeleteProyecto(int id);
    }
}


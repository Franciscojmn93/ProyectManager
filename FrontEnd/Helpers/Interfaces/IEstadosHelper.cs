using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IEstadosHelper
    {
        List<EstadosViewModel> GetEstados();

        EstadosViewModel GetById(int id);
        EstadosViewModel AddEstado(EstadosViewModel model);
        EstadosViewModel EditEstado(EstadosViewModel model);

        void DeleteEstado(int id);
    }
}


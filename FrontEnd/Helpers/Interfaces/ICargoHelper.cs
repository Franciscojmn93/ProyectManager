using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICargoHelper
    {
        List<CargosViewModel> GetCargos();

        CargosViewModel GetById(int id);
        CargosViewModel AddCargo(CargosViewModel model);
        CargosViewModel EditCargo(CargosViewModel model);

        void DeleteCargo(int id);
    }
}

using FrontEnd.Models;
using System.Security.Cryptography;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDepartamentoHelper
    {
        List<DepartamentosViewModel> GetDepartamentos();
        DepartamentosViewModel GetById(int id);
        DepartamentosViewModel AddDepartamento(DepartamentosViewModel model);
        DepartamentosViewModel EditDepartamento(DepartamentosViewModel model);

       void DeleteDepartamento(int id);
    }
}

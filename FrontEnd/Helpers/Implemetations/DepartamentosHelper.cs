using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class DepartamentoHelper : IDepartamentoHelper
    {
        IServiceRepository _repository;

        public DepartamentoHelper(IServiceRepository repository)
        {
            _repository = repository;
        }

        public DepartamentosViewModel AddDepartamento(DepartamentosViewModel departamento)
        {
            DepartamentosViewModel viewModel = new DepartamentosViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Departamentos/", departamento);
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<DepartamentosViewModel>(contenido);
            }
            return viewModel;
        }

        public void DeleteDepartamento(int id)
        {
            HttpResponseMessage responsseMessage = _repository.DeleteResponse("api/Departamentos/" + id.ToString());
            if (responsseMessage != null) 
            {
                var contenido = responsseMessage.Content.ReadAsStringAsync().Result; 
            }
        }

        public DepartamentosViewModel EditDepartamento(DepartamentosViewModel model)
        {
            DepartamentosViewModel category = new DepartamentosViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Departamentos/", model);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<DepartamentosViewModel>(content);
            }

            return category;
        }

        public DepartamentosViewModel GetById(int id)
        {
            DepartamentosViewModel viewModel = new DepartamentosViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Departamentos/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<DepartamentosViewModel>(content);
            }

            return viewModel;
        }

        public List<DepartamentosViewModel> GetDepartamentos()
        {
            List<DepartamentosViewModel> lista = new List<DepartamentosViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Departamentos/");
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<DepartamentosViewModel>>(contenido);
            }

            return lista;
        }
    }
}

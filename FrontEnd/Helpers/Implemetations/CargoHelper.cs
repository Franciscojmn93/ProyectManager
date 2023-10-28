using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class CargoHelper : ICargoHelper
    {
        IServiceRepository _repository;

        public CargoHelper(IServiceRepository repository)
        {
            _repository = repository;
        }

        public CargosViewModel AddCargo(CargosViewModel model)
        {
            CargosViewModel viewModel = new CargosViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Cargo/", model);
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<CargosViewModel>(contenido);
            }
            return viewModel;
        }

        public void DeleteCargo(int id)
        {
            HttpResponseMessage responsseMessage = _repository.DeleteResponse("api/Cargo/" + id.ToString());
            if (responsseMessage != null)
            {
                var contenido = responsseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public CargosViewModel EditCargo(CargosViewModel model)
        {
            CargosViewModel cargo = new CargosViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Cargo/", model);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cargo= JsonConvert.DeserializeObject<CargosViewModel>(content);
            }

            return cargo;
        }

        public CargosViewModel GetById(int id)
        {
            CargosViewModel viewModel = new CargosViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cargo/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<CargosViewModel>(content);
            }

            return viewModel;
        }

        public List<CargosViewModel> GetCargos()
        {
            List<CargosViewModel> lista = new List<CargosViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Cargo/");
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CargosViewModel>>(contenido);
            }

            return lista;
        }
    }
}

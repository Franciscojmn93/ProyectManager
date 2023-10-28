using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class EstadosHelper : IEstadosHelper
    {
        IServiceRepository _repository;

        public EstadosHelper(IServiceRepository repository) 
        {
            _repository = repository;
        }

        public EstadosViewModel AddEstado(EstadosViewModel model)
        {
            EstadosViewModel viewModel = new EstadosViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Estados/", model);
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<EstadosViewModel>(contenido);
            }
            return viewModel;
        }

        public void DeleteEstado(int id)
        {
            HttpResponseMessage responsseMessage = _repository.DeleteResponse("api/Estados/" + id.ToString());
            if (responsseMessage != null)
            {
                var contenido = responsseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public EstadosViewModel EditEstado(EstadosViewModel model)
        {
            EstadosViewModel viewModel = new EstadosViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Estados/", model);
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<EstadosViewModel>(contenido);
            }
            return viewModel;
        }

        public EstadosViewModel GetById(int id)
        {
            EstadosViewModel viewModel = new EstadosViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Estados/" + id.ToString());
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<EstadosViewModel>(contenido);
            }
            return viewModel;
        }

        public List<EstadosViewModel> GetEstados()
        {
            List<EstadosViewModel> lista = new List<EstadosViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Estados/");
            if (responseMessage != null)
            {
                var contenido = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EstadosViewModel>>(contenido);
            }

            return lista;
        }
    }
}

using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class SpUsuariosHelper : ISpUsuariosHelper
    {
        IServiceRepository _repository;

        public SpUsuariosHelper(IServiceRepository repository) 
        {
            _repository = repository;
        }

        public List<SpUsuariosViewModel> GetUsuarios()
        {
            List<SpUsuariosViewModel> lista = new List<SpUsuariosViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/SpUsuarios");
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<SpUsuariosViewModel>>(content);
            }

            return lista;
        }
    }
}

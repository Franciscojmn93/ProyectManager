using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class RolHelper : IRolHelper
    {
        IServiceRepository _repository;

        public RolHelper(IServiceRepository repository) 
        {
            _repository = repository;
        }

        public List<RolViewModelcs> GetRols()
        {
            List<RolViewModelcs> lista = new List<RolViewModelcs>();
            HttpResponseMessage response = _repository.GetResponse("api/Roles");



            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<RolViewModelcs>>(content);
            }

            return lista;
        }
    }
}
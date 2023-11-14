using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class UsuarioHelper : IUsuarioHelper
    {
        IServiceRepository _repository;
        
        public UsuarioHelper(IServiceRepository repository) 
        {
            _repository = repository;
        }

        public UsuarioViewModel AddUsuario(UsuarioViewModel usuario)
        {
            UsuarioViewModel product = new UsuarioViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Usuarios/", usuario);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            }

            return product;
        }

        public void DeleteUsuario(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Usuarios/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
        }

        public UsuarioViewModel EditUsuario(UsuarioViewModel usuario)
        {
            UsuarioViewModel product = new UsuarioViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Usuarios/", usuario);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            }

            return product;
        }

        public UsuarioViewModel GetById(int id)
        {
            UsuarioViewModel Product = new UsuarioViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Usuarios/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Product = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            }

            return Product;
        }


        public List<UsuarioViewModel> GetUsuarios()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Usuarios/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);
            }

            return lista;
        }


        public bool ExisteUsuario(string NombreUsaurio)
        {
            var nombreUsuario = NombreUsaurio;
            HttpResponseMessage responseMessage = _repository.GetResponse($"api/Usuarios/VerificarUsuario?nombreUsuario={nombreUsuario}");
            if (responseMessage.ReasonPhrase == "OK")
            {
                return true;
            }
            return false;
        }
    }
}

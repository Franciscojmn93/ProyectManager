using Entities.Entities;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class ProyectosHelper : IProyectosHelper 
    {
        IServiceRepository _repository;

        public ProyectosHelper(IServiceRepository repository)
        {
            _repository = repository;
        }

        public ProyectosViewModel AddProyecto(ProyectosViewModel proyecto)
        {
            ProyectosViewModel proyectos = new ProyectosViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("/api/Proyectos/", proyecto);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                proyectos = JsonConvert.DeserializeObject<ProyectosViewModel>(content);
            }
            return proyectos;
        }

        public void DeleteProyecto(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("/api/Proyectos/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
               
            }
        }

        public ProyectosViewModel EditProyecto(ProyectosViewModel proyecto)
        {
            ProyectosViewModel proyectos = new ProyectosViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("/api/Proyectos/", proyecto);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                proyectos = JsonConvert.DeserializeObject<ProyectosViewModel>(content);
            }
            return proyectos;
        }

        public ProyectosViewModel GetById(int id)
        {
            ProyectosViewModel proyectos = new ProyectosViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("/api/Proyectos/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                proyectos = JsonConvert.DeserializeObject<ProyectosViewModel>(content);
            }
            return proyectos;
        }

        public List<ProyectosViewModel> GetProyectos()
        {
            List<ProyectosViewModel> lista = new List<ProyectosViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Proyectos/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ProyectosViewModel>>(content);
            }

            return lista;
        }
    }
}

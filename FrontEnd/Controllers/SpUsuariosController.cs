using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SpUsuariosController : Controller
    {
        ISpUsuariosHelper _spUsuariosHelper;

        public SpUsuariosController(ISpUsuariosHelper spUsuariosHelper)
        {
            _spUsuariosHelper = spUsuariosHelper;
        }




        // GET: SpUsuariosController
        public ActionResult Index()
        {
            List<SpUsuariosViewModel> usuarios = _spUsuariosHelper.GetUsuarios();
            return View(usuarios);
        }

     }
}

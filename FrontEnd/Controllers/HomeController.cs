using Entities.Entities;
using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller

    {
        IUsuarioHelper _usuarioHelper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUsuarioHelper usuarioHelper)
        {
            _usuarioHelper = usuarioHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var NombreUsaurio = new UsuarioViewModel
            {
                NombreUsaurio = Environment.UserName
            };
            return View(NombreUsaurio);
        }

        public IActionResult Login(String NombreUsaurio)
        {
            var respuesta = _usuarioHelper.ExisteUsuario(NombreUsaurio);
            if(respuesta == true)
            {
                return RedirectToAction(nameof(Principal));

            }else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
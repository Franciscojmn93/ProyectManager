using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProyectosController : Controller
    {
        IProyectosHelper _proyectosHelper;
        IUsuarioHelper _usuarioHelper;
        IEstadosHelper _estadosHelper;

        public ProyectosController(IProyectosHelper proyectosHelper, IUsuarioHelper usuarioHelper, IEstadosHelper estadosHelper)
        {
            _proyectosHelper = proyectosHelper;
            _usuarioHelper = usuarioHelper;
            _estadosHelper = estadosHelper;
        }


        // GET: ProyectosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProyectosController/Details/5
        public ActionResult Details(int id)
        {
            ProyectosViewModel viewModel = _proyectosHelper.GetById(id);
            return View(viewModel);
        }

        // GET: ProyectosController/Create
        public ActionResult Create()
        {
           ProyectosViewModel viewModel = new ProyectosViewModel();
            viewModel.usuarios = _usuarioHelper.GetUsuarios();
            viewModel.estados = _estadosHelper.GetEstados();
            return View(viewModel);
                
        }

        // POST: ProyectosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProyectosViewModel proyectos)
        {
            try
            {
                _proyectosHelper.AddProyecto(proyectos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProyectosController/Edit/5
        public ActionResult Edit(int id)
        {
            ProyectosViewModel viewModel = new ProyectosViewModel();
            viewModel.usuarios = _usuarioHelper.GetUsuarios();
            viewModel.estados = _estadosHelper.GetEstados();
            return View(viewModel);
        }

        // POST: ProyectosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProyectosViewModel proyectos)
        {
            try
            {
                _proyectosHelper.EditProyecto(proyectos);   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProyectosController/Delete/5
        public ActionResult Delete(int id)
        {
            ProyectosViewModel proyectos = _proyectosHelper.GetById(id); 
            return View(proyectos);
        }

        // POST: ProyectosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProyectosViewModel proyectos)
        {
            try
            {
                _proyectosHelper.DeleteProyecto(proyectos.IdProyecto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EstadosController : Controller
    {
        IEstadosHelper estadosHelper;

        public EstadosController(IEstadosHelper _estadosHelper)
        {
            estadosHelper = _estadosHelper;
        }


        // GET: EstadosController
        public ActionResult Index()
        {
            List<EstadosViewModel> estados = estadosHelper.GetEstados();
            return View(estados);
        }

        // GET: EstadosController/Details/5
        public ActionResult Details(int id)
        {
            EstadosViewModel estados = estadosHelper.GetById(id);
            return View(estados);
        }

        // GET: EstadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadosViewModel estados)
        {
            try
            {
                estadosHelper.AddEstado(estados);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadosController/Edit/5
        public ActionResult Edit(int id)
        {
            EstadosViewModel estados = estadosHelper.GetById(id);
            return View(estados);
        }

        // POST: EstadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstadosViewModel estados)
        {
            try
            {
                EstadosViewModel estado = estadosHelper.EditEstado(estados);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadosController/Delete/5
        public ActionResult Delete(int id)
        {
            EstadosViewModel estados = estadosHelper.GetById(id);
            return View(estados);
        }

        // POST: EstadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EstadosViewModel estados)
        {
            try
            {
                estadosHelper.DeleteEstado(estados.IdEstado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

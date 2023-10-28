using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CargosController : Controller
    {
        ICargoHelper cargoHelper;

        public CargosController(ICargoHelper _cargoHelper)
        {
            cargoHelper = _cargoHelper;
        }


        // GET: CargosController
        public ActionResult Index()
        {
            List<CargosViewModel> cargos = cargoHelper.GetCargos();
            return View(cargos);
        }

        // GET: CargosController/Details/5
        public ActionResult Details(int id)
        {
            CargosViewModel cargos = cargoHelper.GetById(id);
            return View(cargos);
        }

        // GET: CargosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargosViewModel cargos)
        {
            try
            {
                cargoHelper.AddCargo(cargos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CargosController/Edit/5
        public ActionResult Edit(int id)
        {
            CargosViewModel cargos = cargoHelper.GetById(id);
            return View(cargos);
        }

        // POST: CargosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargosViewModel cargos)
        {
            try
            {
                CargosViewModel cargo = cargoHelper.EditCargo(cargos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CargosController/Delete/5
        public ActionResult Delete(int id)
        {
            CargosViewModel cargos = cargoHelper.GetById(id);
            return View(cargos);
        }

        // POST: CargosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CargosViewModel cargos)
        {
            try
            {
                cargoHelper.DeleteCargo(cargos.IdCargo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

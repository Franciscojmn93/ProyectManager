using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DepartamentosController : Controller
    {
        IDepartamentoHelper departamentoHelper;

        public DepartamentosController(IDepartamentoHelper _departamentoHelper)
        {
            departamentoHelper = _departamentoHelper;
        }


        // GET: DepartamentosController
        public ActionResult Index()
        {
            List<DepartamentosViewModel> departamentos = departamentoHelper.GetDepartamentos();                                                                                                                                                                         
            return View(departamentos);
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            DepartamentosViewModel departamentos = departamentoHelper.GetById(id);
            return View(departamentos);
        }

        // GET: DepartamentosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentosViewModel departamentos)
        {
            try
            {
                departamentoHelper.AddDepartamento(departamentos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentosController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartamentosViewModel departamentos = departamentoHelper.GetById(id);
            return View(departamentos);
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartamentosViewModel departamento)
        {
            try
            {
                DepartamentosViewModel departamentos = departamentoHelper.EditDepartamento(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentosController/Delete/5
        public ActionResult Delete(int id)
        {
            DepartamentosViewModel departamentos = departamentoHelper.GetById(id);
            return View(departamentos);
        }

        // POST: DepartamentosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DepartamentosViewModel departamento)
        {
            try
            {
                departamentoHelper.DeleteDepartamento(departamento.IdDepartamento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Entities.Entities;
using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuariosController : Controller
    {
        IUsuarioHelper _usuarioHelper;
        ICargoHelper _cargoHelper;
        IRolHelper _rolHelper;
        IDepartamentoHelper _departamentoHelper;

        public UsuariosController(ICargoHelper cargoHelper, IRolHelper rolHelper, IDepartamentoHelper departamentoHelper, IUsuarioHelper usuarioHelper)
        {
            _usuarioHelper= usuarioHelper;
            _cargoHelper = cargoHelper;
            _rolHelper = rolHelper;
            _departamentoHelper = departamentoHelper;
        }



        // GET: UsuariosController
        public ActionResult Index()
        {
            List<UsuarioViewModel> usuarios = _usuarioHelper.GetUsuarios();
            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            UsuarioViewModel usuario = _usuarioHelper.GetById(id);
            return View(usuario);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.roles = _rolHelper.GetRols();
            usuario.Cargos = _cargoHelper.GetCargos();
            usuario.Departamentos = _departamentoHelper.GetDepartamentos();

            return View(usuario);
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.AddUsuario(usuario);

                return RedirectToAction("Index", "SpUsuarios");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel usuario = _usuarioHelper.GetById(id);
            usuario.roles = _rolHelper.GetRols();
            usuario.Cargos = _cargoHelper.GetCargos();
            usuario.Departamentos = _departamentoHelper.GetDepartamentos();

            return View(usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.EditUsuario(usuario);
                return RedirectToAction("Index", "SpUsuarios");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioViewModel usuario = _usuarioHelper.GetById(id);
            return View(usuario);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.DeleteUsuario(usuario.IdUsuario);
                return RedirectToAction("Index", "SpUsuarios");
            }
            catch
            {
                return View();
            }
        }
    }
}

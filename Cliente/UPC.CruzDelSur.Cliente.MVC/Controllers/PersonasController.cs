using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CruzDelSur.Datos.Contratos;
using UPC.CruzDelSur.Datos.Fake;

namespace UPC.CruzDelSur.Cliente.MVC.Controllers
{
    public class PersonasController : Controller
    {
        readonly IContextoDatos _db = new ContextoDatosFake();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = _db.Personas.ObtenerTodos();

            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

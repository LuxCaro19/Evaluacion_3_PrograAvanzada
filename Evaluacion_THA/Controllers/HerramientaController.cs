using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluacion_THA.Models;

namespace Evaluacion_THA.Controllers
{
    public class HerramientaController : Controller
    {
        private ModelData db = new ModelData();

        [HttpGet]
        public ActionResult listar()
        {

            var herramientas = from h in db.herramienta
                               select h;

            return View(herramientas.ToList());

        }

        [HttpGet]
        public ActionResult crear()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult crear(herramienta h)
        {
            if (ModelState.IsValid)
            {
                db.herramienta.Add(h);
                db.SaveChanges();
                TempData["mensaje"] = "Se ha guardado la herramienta.";
                return RedirectToAction("listar", "Herramienta");
            }
            return View(h);
        }

        [HttpGet]
        public ActionResult editar(int? id)
        {

            var h = db.herramienta.Find(id);
            if (h != null)
            {
                return View(h);
            }
            return RedirectToAction("listar", "Herramienta");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editar(herramienta h)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Datos de la herramienta cambiados.";
                return RedirectToAction("listar", "Herramienta");
            }
            return View(h);
        }

        [HttpGet]
        public ActionResult eliminar(int? id)
        {

            var herramientas = db.herramienta.Find(id);

            return View(herramientas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eliminar(herramienta h)
        {

            

            var eliminar_h = db.herramienta.Find(h.id);
            db.herramienta.Remove(eliminar_h);
            int n = db.SaveChanges();
            if (n > 0)
            {
                TempData["mensaje"] = "herramienta eliminada.";
                return RedirectToAction("listar", "Herramienta");
            }
            return View();
        }
        



        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {

                db.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluacion_THA.Models;

namespace Evaluacion_THA.Controllers
{
    public class AsignarController : Controller
    {
        private ModelData db = new ModelData();

        [HttpGet]
        public ActionResult listar()
        {
            var asignaciones = from a in db.asignar
                               select a;

            return View(asignaciones.ToList());

        }

        [HttpGet]
        public ActionResult crear()
        {
            

            var trabajadores = from t in db.trabajador
                               select t;
            ViewBag.trabajadoresID = new SelectList(trabajadores.ToList(), "id", "nombre");

            var herramientas = from h in db.herramienta
                               select h;
            ViewBag.herramientasID = new SelectList(herramientas.ToList(), "id", "nombre");

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult crear(asignar a)
        {
            if (ModelState.IsValid)
            {
               
                db.asignar.Add(a);
                db.SaveChanges();
                TempData["mensaje"] = "Se ha asignado la herramienta";
                return RedirectToAction("listar", "Asignar");
            }

            var trabajadores = from t in db.trabajador select t;
            ViewBag.trabajadoresID= new SelectList(trabajadores.ToList(), "id", "nombre", a.idTrabajador);

            var herramientas = from h in db.herramienta select h;
            ViewBag.herramientasID = new SelectList(herramientas.ToList(), "id", "nombre", a.idHerramienta);


            return View(a);
        }

        [HttpGet]
        public ActionResult editar(int? id)
        {

            var a = db.asignar.Find(id);
            if (a != null) { 
                var trabajadores = from t in db.trabajador select t;
                ViewBag.trabajadoresID = new SelectList(trabajadores.ToList(), "id", "nombre");

                var herramientas = from h in db.herramienta select h;
                ViewBag.herramientasID = new SelectList(herramientas.ToList(), "id", "nombre");


            return View(a);
            }
            return RedirectToAction("listar", "asignar");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editar(asignar a)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Cambio de asignacion realizada.";
                return RedirectToAction("listar", "asignar");
            }

            var trabajadores = from t in db.trabajador select t;
            ViewBag.trabajadoresID = new SelectList(trabajadores.ToList(), "id", "nombre", a.idTrabajador);

            var herramientas = from h in db.herramienta select h;
            ViewBag.herramientasID = new SelectList(herramientas.ToList(), "id", "nombre", a.idHerramienta);
            return View(a);
        }

        [HttpGet]
        public ActionResult eliminar(int? id)
        {

            var herramientas = db.asignar.Find(id);

            return View(herramientas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eliminar(asignar a)
        {

            

            var eliminar_a = db.asignar.Find(a.id);
            db.asignar.Remove(eliminar_a);
            int n = db.SaveChanges();
            if (n > 0)
            {
                TempData["mensaje"] = "Asignacion eliminada.";
                return RedirectToAction("listar", "Asignar");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluacion_THA.Models;

namespace Evaluacion_THA.Controllers
{
    public class TrabajadorController : Controller
    {
        private ModelData db = new ModelData();

        [HttpGet]
        public ActionResult listar()
        {

            var trabajadores = from t in db.trabajador
                               select t;

            return View(trabajadores.ToList());

        }

        [HttpGet]
        public ActionResult eliminar(int? id)
        {

            var trabajadores = db.trabajador.Find(id);

            return View(trabajadores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eliminar(trabajador tr)
        {

            

            var trabajador_delete = db.trabajador.Find(tr.id);
            db.trabajador.Remove(trabajador_delete);
            int n = db.SaveChanges();
            if (n > 0)
            {
                TempData["mensaje"] = "El trabajador ha sido eliminado correctamente.";
                return RedirectToAction("listar", "Trabajador");
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
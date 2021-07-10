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
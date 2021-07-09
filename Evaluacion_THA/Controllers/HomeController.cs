using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion_THA.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Interna()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Externa()
        {
            return View();
        }
    }
}
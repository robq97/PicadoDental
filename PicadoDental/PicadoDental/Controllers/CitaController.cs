using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cliente
        public ActionResult NewCita()
        {
            return View();
        }

        public ActionResult CitaList()
        {
            return View();
        }
    }
}
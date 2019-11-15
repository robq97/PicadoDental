using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Cliente
        public ActionResult NewDoctor()
        {
            return View();
        }

        public ActionResult DoctorList()
        {
            return View();
        }
    }
}
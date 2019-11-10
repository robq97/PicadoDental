using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class ClientController : Controller
    {
        // GET: Cliente
        public ActionResult NewClient()
        {
            return View();
        }
        // GET: Cliente
        public ActionResult ClientList()
        {
            return View();
        }

    }
}
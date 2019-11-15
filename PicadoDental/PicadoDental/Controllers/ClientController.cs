using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class ClientController : Controller
    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();

        // GET: Cliente
        public ActionResult NewClient()
        {
            return View();
        }

        public ActionResult AddNewClient(
            string FirstName,
            string LastName,
            string Id,
            string Phone,
            string Email,
            string Gender)
        {
            WS.NewClient(FirstName, LastName, "", Phone, Email, int.Parse(Gender));

            return RedirectToAction("ClientList", "Client");
        }

        public ActionResult ClientList()
        {
            //var clientList = WS.ClientList();

            return View();
        }

        public ActionResult Client()
        {
            return View();
        }
    }
}
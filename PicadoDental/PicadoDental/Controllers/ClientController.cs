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
            string SecondName,
            int Id,
            string Phone,
            string Email,
            int Gender,
            string usuario= "",
            string contrasena= "",
            int tipoCuentaID = 4)
        {
            WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Gender,Id,tipoCuentaID,usuario,contrasena);

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
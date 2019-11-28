using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class DoctorController : Controller
    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
        // GET: Doctor
        public ActionResult NewDoctor()
        {
            return View();
        }

        public ActionResult AddNewDoctor(
            string FirstName,
            string LastName,
            string SecondName,
            int Id,
            string Phone,
            string Email,
            int Gender,
            string usuario,
            string contrasena,
            int tipoCuentaID = 3)

        {
            WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Gender, Id, tipoCuentaID,usuario,contrasena);

            return RedirectToAction("ClientList", "Client");
        }

        public Boolean validacion(string contrasena, string confirmacion)
        {
            if (contrasena.Equals(confirmacion))
            {
                return true;
            }
            return false;
        }
    }
}
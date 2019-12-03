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
        public ActionResult DoctorList()
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
            string Gender,
            string usuario,
            string contrasena,
            string confirmacion,
            int tipoCuentaID = 3)
        {
            if (validacion(contrasena, confirmacion))
            {
                WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);

            
            }
            return RedirectToAction("NewDoctor", "Doctor");

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
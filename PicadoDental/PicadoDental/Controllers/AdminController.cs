using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class AdminController : Controller
    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
        // GET: Admin
        public ActionResult NewAdmin()
        {
            return View();
        }

        public ActionResult NewSecretary()
        {
            return View();
        }

        public ActionResult AddNewAdmin( 
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
            int tipoCuentaID = 1)
        {
            if (validacion(contrasena, confirmacion))
            {
                WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);

                TempData["message"] = "Admin creado con exito.";
            }
        

            return RedirectToAction("NewAdmin", "Admin");
        }

        public Boolean validacion (string contrasena, string confirmacion)
        {
            if (contrasena.Equals(confirmacion))
            {
                return true;
            }
            else
            {
                TempData["message"] = "Las contraseñas no coinciden.";
            }
            return false;
        }

        public ActionResult AddNewSecretary(
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
            int tipoCuentaID = 2)

        {
            if (validacion(contrasena, confirmacion))
            {
                WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);
                TempData["message"] = "Secretario/a creado con exito.";
            }
                

            return RedirectToAction("NewSecretary", "Admin");
        }
    }
}

    


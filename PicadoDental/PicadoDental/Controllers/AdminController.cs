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
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AddNewAdmin( 
            string FirstName,
            string LastName,
            string SecondName,
            string Id,
            string Phone,
            string Email,
            string Gender,
            string usuario,
            string contrasena,
            string confirmacion,
            int tipoCuentaID = 4)
        {
            //if(validacion(contrasena, confirmacion))
            
                WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Convert.ToInt32(Id), tipoCuentaID, usuario, contrasena);
            
        

            return RedirectToAction("AddNewAdmin", "Admin");
        }

        public Boolean validacion (string contrasena, string confirmacion)
        {
            if (contrasena.Equals(confirmacion))
            {
                return true;
            }
            return false;
        }
        
        

        // GET: Admin
        public ActionResult Secretary()
        {
            return View();
        }
        public ActionResult AddNewSecretary(
            string FirstName,
            string LastName,
            string SecondName,
            int Id,
            string Phone,
            string Email,
            int Gender,
            string usuario,
            string contrasena,
            int tipoCuentaID = 4)
        {
            WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Gender, Id, tipoCuentaID, usuario, contrasena);

            return RedirectToAction("AddNewSecretary", "Secretary");
        }
    }
}

    


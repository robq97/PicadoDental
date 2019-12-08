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
        // GET: Secretary
        public ActionResult NewSecretary()
        {
            return View();
        }
        /// <summary>
        /// Method to add a new admin and also their corresponding  try and catch
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="SecondName"></param>
        /// <param name="Id"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Gender"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="confirmacion"></param>
        /// <param name="tipoCuentaID"></param>
        /// <returns></returns>
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
            try
            {
                if (validacion(contrasena, confirmacion))
                {
                    WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);

                    TempData["message"] = "Administrador creado exitosamente.";
                }

                return RedirectToAction("NewAdmin", "Admin");
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }
        /// <summary>
        /// Method to validate the password to have more confiability
        /// </summary>
        /// <param name="contrasena"></param>
        /// <param name="confirmacion"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Method to add a new Secretary and also their corresponding  try and catch
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="SecondName"></param>
        /// <param name="Id"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Gender"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="confirmacion"></param>
        /// <param name="tipoCuentaID"></param>
        /// <returns></returns>
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
            try
            {
                if (validacion(contrasena, confirmacion))
                {
                    WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);
                    TempData["message"] = "Secretario/a creado exitosamente.";
                }

                return RedirectToAction("NewSecretary", "Admin");
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }
    }
}

    


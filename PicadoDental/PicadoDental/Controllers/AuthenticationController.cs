using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{

    [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class AuthenticationController : Controller
    {

        //public ActionResult LogIn()
        //{
        //    if (Session["TipoUsuario"] != null)
        //    {
        //        return RedirectToAction("NewClient", "Client");
        //    }
        //    return View();
        //}

        /// <summary>
        /// Revisa que el admin este con una sesion iniciada
        /// </summary>
        /// <returns>Devuelve el HomePage Publico</returns>
        public ActionResult LogOut()
        {
            if (Session["TipoUsuario"] != null)
            {
                Session["TipoUsuario"] = null;
                Session.Contents.RemoveAll();
                Session.RemoveAll();
                Session.Abandon();
                RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Denied()
        {
            return View();
        }

        public ActionResult Authentication(string usuario, string password)
        {
            EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
            var info = WS.LogIn(usuario, password);

            if (info[1] != null)
            {

                if (info[1] == "1")
                {
                    Session["TipoUsuario"] = "Admin";
                    return RedirectToAction("NewClient", "Client"); //redireccionar a nueva secretaria
                }
                else if (info[1] == "2")
                {
                    Session["TipoUsuario"] = "Secretaria";
                    return RedirectToAction("NewClient", "Client");
                }
                else if (info[1] == "3")
                {
                    Session["TipoUsuario"] = "Doctor";
                    return RedirectToAction("NewAppointment", "Appointment");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return new EmptyResult();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class AuthenticationController : Controller
    {

        public ActionResult LogIn()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("NewClient", "Client");
            }
            return View();
        }

        /// <summary>
        /// Revisa que el admin este con una sesion iniciada
        /// </summary>
        /// <returns>Devuelve el HomePage Publico</returns>
        public ActionResult LogOut()
        {
            if (Session["username"] != null)
            {
                Session["username"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Denied()
        {
            return View();
        }

        public ActionResult  Authentication(string usuario, string password)
        {
            EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
            if (WS.LogIn(usuario, password) == true)
            {
                Session["username"] = usuario.FirstOrDefault();
                return RedirectToAction("NewClient", "Client");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
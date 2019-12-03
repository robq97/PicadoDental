using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{

    //[System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class AuthenticationController : Controller

    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();

        HomeController home = new HomeController();

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
            var info = WS.LogIn(usuario, password);
            ViewBag.Message = null;

            if (info[1] != null)
            {

                if (info[1] == "1")
                {
                    Session["TipoUsuario"] = "Admin";
                    return RedirectToAction("NewSecretary", "Admin"); //redireccionar a nueva secretaria
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
            else if (info[2] == "error")
            {
                ViewBag.Message = "Usuario y/o contraseña incorrectos.";
                usuario = null;
                password = null;
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Message = null;
                return View("~/Views/Home/Index.cshtml");
            }

            return new EmptyResult();
        }
        
    }
}
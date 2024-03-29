﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{

    [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
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
        /// <summary>
        /// Method to do the autenticationn of the users and passwords with their corresponding try and catch 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult Authentication(string usuario, string password)
        {
            try
            {
                var info = WS.LogIn(usuario, password);

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
                        Session["PersonaID"] = info[0];
                        return RedirectToAction("NewAppointment", "Appointment");
                    }
                }
                else if (info[2] == "error")
                {
                    TempData["message"] = "Usuario y/o contraseña incorrectos.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("~/Views/Home/Index.cshtml");
                }
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

            return new EmptyResult();
        }
        
    }
}
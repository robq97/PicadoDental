using PicadoDental.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                var info = WS.DoctorList();
                List<MDoctor> list = new List<MDoctor>();
                if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        MDoctor model = new MDoctor();
                        model.PersonaID = info[i].PersonaID;
                        model.Nombre = info[i].Nombre;
                        model.Apellidos = info[i].Apellidos;
                        model.Cedula = info[i].Cedula;
                        model.Correo = info[i].Correo;
                        model.Telefono = info[i].Telefono;
                        list.Add(model);
                    }
                }
                return View(list);
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
            try
            {
                if (validacion(contrasena, confirmacion))
                {
                    WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Convert.ToInt32(Gender), Id, tipoCuentaID, usuario, contrasena);
                    TempData["message"] = "Doctor creado exitosamente.";
                }
                return RedirectToAction("DoctorList", "Doctor");
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
        public Boolean validacion(string contrasena, string confirmacion)
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
    }
}
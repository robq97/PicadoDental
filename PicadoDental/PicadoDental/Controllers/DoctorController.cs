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
                TempData["message"] = "Doctor creado exitosamente.";
            }
            return RedirectToAction("DoctorList", "Doctor");

        }

        public ActionResult Doctor(int id)
        {
            var info = WS.ObtenerInfoDoctor(id);
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
                    model.Genero = info[i].Genero;
                    model.Telefono = info[i].Telefono;
                    model.Correo = info[i].Correo;
                    list.Add(model);
                }
            }
            return View(list);
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

        /// <summary>
        /// Method to apply for appointment list of a specific Doctor
        /// </summary>
        /// <returns>All the list of appointments</returns>
        // GET: AppointmentListOfDoctor
        public ActionResult AppointmentListOfDoctor(int id)
        {
            List<MAppointmentList> list = new List<MAppointmentList>();
            try
            {
                var info = WS.CitaList();
                if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        if (info[i].DoctorID == id)
                        {
                            ViewBag.Doctor = info[i].ClienteNombre + " " + info[i].ClienteApellidos;
                            MAppointmentList model = new MAppointmentList();
                            model.Fecha = info[i].Fecha;
                            model.ClienteNombre = info[i].ClienteNombre;
                            model.ClienteApellidos = info[i].ClienteApellidos;
                            model.DoctorNombre = info[i].DoctorNombre;
                            model.DoctorApellidos = info[i].DoctorApellidos;
                            model.Detalles = info[i].Detalles;
                            model.ClienteID = info[i].ClienteID;
                            model.CitaID = info[i].CitaID;
                            list.Add(model);
                        }
                    }
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
            return View(list);
        }
        public ActionResult UpdateDoctor(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateDoctor(int id, MDoctor doctor)
        {
            doctor.PersonaID = id;
            ViewBag.ID = id;
            try
            {
                WS.ModifyDoctor(id, doctor.Telefono, doctor.Correo);
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
            
            return RedirectToAction("DoctorList", "Doctor");
        }
    }
}
using PicadoDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class AppointmentController : Controller
    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();

        //GET: NewAppointment
        public ActionResult NewAppointment()
        {
            // Dropdown of clients
            var infoClientes = WS.ListaClientes();
            List<MAppointmentList> listaClientes = new List<MAppointmentList>();
            for (int i = 0; i < infoClientes.Length; i++)
            {
                MAppointmentList cliente = new MAppointmentList();
                cliente.ClienteID =  infoClientes[i].ClienteID;
                cliente.ClienteNombre = infoClientes[i].ClienteNombre;
                listaClientes.Add(cliente);
            }
            ViewBag.Cliente = new SelectList(listaClientes, "ClienteID", "ClienteNombre");
            // Dropdown of doctors
            var infoDoctores = WS.ListaDoctores();
            List<MAppointmentList> listaDoctores = new List<MAppointmentList>();
            for (int i = 0; i < infoDoctores.Length; i++)
            {
                MAppointmentList doctor = new MAppointmentList();
                doctor.DoctorID = infoDoctores[i].DoctorID;
                doctor.DoctorNombre= infoDoctores[i].DoctorNombre;
                listaDoctores.Add(doctor);
            }
            ViewBag.Doctor = new SelectList(listaDoctores, "DoctorID", "DoctorNombre");
            return View();
        }
        
        //GET: NewAppointment
        [HttpPost]
        public ActionResult NewAppointment(MAppointmentList lista)
        {
            // Dropdown of clients
            var infoClientes = WS.ListaClientes();
            List<MAppointmentList> listaClientes = new List<MAppointmentList>();
            for (int i = 0; i < infoClientes.Length; i++)
            {
                MAppointmentList cliente = new MAppointmentList();
                cliente.ClienteID = infoClientes[i].ClienteID;
                cliente.ClienteNombre = infoClientes[i].ClienteNombre;
                listaClientes.Add(cliente);
            }
            ViewBag.Cliente = new SelectList(listaClientes, "ClienteID", "ClienteNombre");

            // Dropdown of doctors
            var infoDoctores = WS.ListaDoctores();
            List<MAppointmentList> listaDoctores = new List<MAppointmentList>();
            for (int i = 0; i < infoDoctores.Length; i++)
            {
                MAppointmentList doctor = new MAppointmentList();
                doctor.DoctorID = infoDoctores[i].DoctorID;
                doctor.DoctorNombre = infoDoctores[i].DoctorNombre;
                listaDoctores.Add(doctor);
            }
            ViewBag.Doctor = new SelectList(listaDoctores, "DoctorID", "DoctorNombre");
            DateTime FechaHora = lista.Fecha.Add(lista.Hora.TimeOfDay);
            WS.NewAppointment(lista.ClienteID, lista.DoctorID, FechaHora.ToString(), lista.Detalles, lista.Comentarios);
            TempData["message"] = "Cita creada exitosamente.";
            return RedirectToAction("NewAppointment", "Appointment");
        }
        /// <summary>
        /// Method to apply for appointment list
        /// </summary>
        /// <returns>All the list of appointments</returns>
        // GET: AppointmentList
        public ActionResult AppointmentList()
        {
            var info = WS.CitaList();
            List<MAppointmentList> list = new List<MAppointmentList>();
            if(info [0] != null)
            {
                for (int i = 0; i < info.Length; i++)
                {
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
            return View(list);
        }

        /// <summary>
        /// Method to apply a details of specific appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns details of specific appointment</returns>
        // GET: Appointment
        public ActionResult Appointment(int id)
        {
            var info = WS.CitaListByID(id);
            List<MAppointmentList> list = new List<MAppointmentList>();
            if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                    MAppointmentList model = new MAppointmentList();
                    model.Fecha = info[i].Fecha;
                    model.ClienteNombre = info[i].ClienteNombre;
                    model.ClienteApellidos = info[i].ClienteApellidos;
                    model.DoctorNombre = info[i].DoctorNombre;
                    model.DoctorApellidos = info[i].DoctorApellidos;
                    model.Detalles = info[i].Detalles;
                    model.ClienteID = info[i].ClienteID;
                    model.DoctorTelefono = info[i].DoctorTelefono;
                    model.DoctorCorreo = info[i].DoctorCorreo;
                    model.ClienteTelefono = info[i].ClienteTelefono;
                    model.ClienteCorreo = info[i].ClienteCorreo;
                    model.Comentarios = info[i].Comentarios;
                    model.CitaID = info[i].CitaID;
                    list.Add(model);
                    }
            }
            return View(list);
        }
        /// <summary>
        /// View to change appointment information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: UpdateAppointment
        public ActionResult UpdateAppointment(int id)
        {
            ViewBag.ID = id;
            // Dropdown of doctors
            var infoDoctores = WS.ListaDoctores();
            List<MAppointmentList> listaDoctores = new List<MAppointmentList>();
            for (int i = 0; i < infoDoctores.Length; i++)
            {
                MAppointmentList doctor = new MAppointmentList();
                doctor.DoctorID = infoDoctores[i].DoctorID;
                doctor.DoctorNombre = infoDoctores[i].DoctorNombre;
                listaDoctores.Add(doctor);
            }
            ViewBag.Doctor = new SelectList(listaDoctores, "DoctorID", "DoctorNombre");
            return View();
        }
        /// <summary>
        /// Method to update information of an apointment 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        // GET: UpdateAppointment
        [HttpPost]
        public ActionResult UpdateAppointment(int id, MAppointmentList cita)
        {
            // Dropdown of doctors
            var infoDoctores = WS.ListaDoctores();
            List<MAppointmentList> listaDoctores = new List<MAppointmentList>();
            for (int i = 0; i < infoDoctores.Length; i++)
            {
                MAppointmentList doctor = new MAppointmentList();
                doctor.DoctorID = infoDoctores[i].DoctorID;
                doctor.DoctorNombre = infoDoctores[i].DoctorNombre;
                listaDoctores.Add(doctor);
            }
            ViewBag.Doctor = new SelectList(listaDoctores, "DoctorID", "DoctorNombre");
            DateTime FechaHora = cita.Fecha.Add(cita.Hora.TimeOfDay);
            WS.ModifyAppointment(id, cita.DoctorID + "", FechaHora + "", cita.Detalles, cita.Comentarios);
            TempData["message"] = "Cita modificada exitosamente.";
            return RedirectToAction("UpdateAppointment", "Appointment");
        }

    }
}
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
        //GET: NewAppointment
        public ActionResult NewAppointment()
        {
            return View();
        }
        // GET: AppointmentList
        public ActionResult AppointmentList()
        {
            EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
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
        // GET: Appointment
        public ActionResult Appointment(int id)
        {
            EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
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
        // GET: UpdateAppointment
        public ActionResult UpdateAppointment()
        {
            return View();
        }

        
    }
}
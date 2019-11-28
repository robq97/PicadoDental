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
            return View();
        }
        // GET: Appointment
        public ActionResult Appointment()
        {
            return View();
        }
        // GET: UpdateAppointment
        public ActionResult UpdateAppointment()
        {
            return View();
        }
    }
}
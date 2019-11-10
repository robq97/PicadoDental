using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult NewAppointment()
        {
            return View();
        }
        // GET: Appointment
        public ActionResult AppoitmentList()
        {
            return View();
        }


    }
}
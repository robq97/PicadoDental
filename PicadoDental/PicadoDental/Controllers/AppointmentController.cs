﻿using System;
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

        public ActionResult AppointmentList()
        {
            return View();
        }

        public ActionResult Appointment()
        {
            return View();
        }
    }
}
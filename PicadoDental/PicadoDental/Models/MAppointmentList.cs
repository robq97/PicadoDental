﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicadoDental.Models
{
    public class MAppointmentList
    {

        public DateTime Fecha { get; set; }
        public String ClienteNombre { get; set; }
        public String ClienteApellidos { get; set; }
        public String DoctorNombre { get; set; }
        public String DoctorApellidos { get; set; }
        public String Detalles { get; set; }
        public int ClienteID { get; set; }
        public String DoctorTelefono { get; set; }
        public String DoctorCorreo { get; set; }
        public String ClienteTelefono { get; set; }
        public String ClienteCorreo { get; set; }
        public String Comentarios { get; set; }
        public int CitaID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Hora { get; set; }

    }
}
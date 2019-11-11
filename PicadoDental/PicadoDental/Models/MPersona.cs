using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicadoDental.Models
{
    public class MPersona
    {
        public short Personaid { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public short Generoid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicadoDental.Models
{
    public class MCliente
    {

        public int ClienteID { get; set; }
        public int PersonaID { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }
        public int GeneroID { get; set; }
        public String Genero { get; set; }
        public int Cedula { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
    }
}
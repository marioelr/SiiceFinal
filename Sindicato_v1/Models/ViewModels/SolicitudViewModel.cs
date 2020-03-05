using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sindicato_v1.Models.ViewModels
{
    public class SolicitudViewModel
    {
        public string primer_Apellido { get; set; }
        public string segundo_Apellido { get; set; }
        public long cedula { get; set; }
        public string nombre { get; set; }
        public string estado_Civil { get; set; }
        public string genero { get; set; }
        public DateTime fecha_Nac { get; set; }
        public string correo_Electronico { get; set; }
        public int telefono { get; set; }

        public string profesion { get; set; }
        public string grado_Academico { get; set; }
        public string colegio_Profesional { get; set; }
        public string puesto { get; set; }

        public string nom_Compania { get; set; }

        public string ubicacion { get; set; }
        public string departamento { get; set; }


    }
}
using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class SelectAgremiadosViewModel
    {

        public int id_Persona { get; set; }
        public int id_Agre { get; set; }
        public long cedula { get; set; }
        public string nombre { get; set; }
        public string primer_Apellido { get; set; }
        public string segundo_Apellido { get; set; }
        public string genero { get; set; }
        public string ecivil { get; set; }
        public int telefono { get; set; }
        public string correo_Electronico { get; set; }
        public DateTime fecha_n { get; set; }
        public DateTime fecha_reg { get; set; }
        public string direccion { get; set; }
        public string nom_comp { get; set; }
        public string  col_pro { get; set; }
        public string g_acade { get; set; }
        public string puesto { get; set; }
        public string departamento { get; set; }
        public string profesion { get; set; }
        public string ubicacion { get; set; }
        public int afiliado { get; set; }

    }
}
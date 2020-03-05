using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class SelectDeduccionesViewModel
    {

        public int id{ get; set; }
        public long cedula { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
        public string puesto { get; set; }
        public DateTime fecha_deduccion { get; set; }
        public decimal monto { get; set; }
    }
}
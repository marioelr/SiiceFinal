using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddDeduccionesViewModel
    {

        public int id_Ded { get; set; }

        public DateTime fecha_Ded { get; set; }

        public decimal monto_Ded { get; set; }

        public int id_Agre { get; set; }

        public int cedula { get; set; }
    }
}
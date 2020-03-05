using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class LoadDeduccionesViewModel
    {
        public string Cedula { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
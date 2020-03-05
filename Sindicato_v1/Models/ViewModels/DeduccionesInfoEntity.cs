using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class DeduccionesInfoEntity
    {
        public int id_Deduccion { get; set; }
        public long cedula { get; set; }
        public DateTime fecha_Deduccion { get; set; }
        public decimal monto { get; set; }
        public int id_Agremiado { get; set; }
        public int estado { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sindicato_v1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Deduccion
    {
        public int id_Deduccion { get; set; }
        public System.DateTime fecha_Deduccion { get; set; }
        public decimal monto { get; set; }
        public int id_Agremiado { get; set; }
        public int estado { get; set; }
    
        public virtual Tbl_Agremiado Tbl_Agremiado { get; set; }
    }
}
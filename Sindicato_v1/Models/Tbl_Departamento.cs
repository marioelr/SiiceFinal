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
    
    public partial class Tbl_Departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Departamento()
        {
            this.Tbl_Agremiado = new HashSet<Tbl_Agremiado>();
            this.Tbl_Empleado = new HashSet<Tbl_Empleado>();
        }
    
        public int id_Departamento { get; set; }
        public string departamento { get; set; }
        public int id_Compania { get; set; }
        public string ubicacion { get; set; }
        public int estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Agremiado> Tbl_Agremiado { get; set; }
        public virtual Tbl_Compania Tbl_Compania { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Empleado> Tbl_Empleado { get; set; }
    }
}
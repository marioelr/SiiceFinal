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
    
    public partial class Tbl_NoticiasPDF
    {
        public int id_Noticia { get; set; }
        public System.DateTime fecha_Creacion_N { get; set; }
        public string titulo_Noticia { get; set; }
        public string subtitulo_Noticia { get; set; }
        public string contenido_Noticia { get; set; }
        public Nullable<int> estado { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class NoticasInfoEntity
    {
        public int id_Noticias { get; set; }
        public DateTime fecha_Creacion { get; set; }
        public String titulo { get; set; }
        public String subtitulo { get; set; }
        public String texto { get; set; }
        public int estado { get; set; }
    }
}
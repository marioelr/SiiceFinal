using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddNoticiasViewModel
    {
        public int id_Noticias { get; set; }
        public DateTime fecha_Creacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un título")]
        [DataType(DataType.Text)]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un subtitulo")]
        [DataType(DataType.Text)]
        [Display(Name = "Subtitulo")]
        public string subtitulo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un texto")]
        [Display(Name = "Cuerpo del documento")]
        [DataType(DataType.MultilineText)]
        public string texto { get; set; }
        public int estado { get; set; }
    }
}
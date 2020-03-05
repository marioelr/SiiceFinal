using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sindicato_v1.Models.ViewModels
{
    public class EditPerfilViewModels
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string p_apellido { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string s_apellido { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo no válido")]
        public string correo_Electronico { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        //[RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        [DataType(DataType.Text)]
        public string direccion { get; set; }
    }
}
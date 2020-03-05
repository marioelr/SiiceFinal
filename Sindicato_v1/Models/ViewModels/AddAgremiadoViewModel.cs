using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddAgremiadoViewModel
    {
        public int id_Persona { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public long cedula { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string primer_apellido { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string segundo_apellido { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Nacionalidad")]
        public int nacionalidad { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Estado Civil")]
        [Required]
        public int id_ECivil { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        //[RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo no válido")]
        public string correo_Electronico { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fecha_Nac { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string contrasenia { get; set; }

        [Required]
        [Display(Name = "Confirmar contraseña")]
        public string conf_contrasenia { get; set; }

        [Required]
        [Display(Name = "Tipo de usuario")]
        ////Tipo usuario
        public int id_TipoUsu { get; set; }

        [Required]
        ////Rol 
        public int id_Rol { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        ////Empleado 
        public int id_Departamento { get; set; }


        [Required]
        //[StringLength(50)]
        [Display(Name = "Profesion")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string profesion { get; set; }

        [Required]
        //[StringLength(50)]
        [Display(Name = "Colegio Profesional")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string colegio_Pro { get; set; }

        [Required]
        //[StringLength(50)]
        [Display(Name = "Puesto")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string puesto { get; set; }

        [Required]
        //[StringLength(50)]
        [Display(Name = "Grado Académico")]
        public string g_Academico { get; set; }
    }
}

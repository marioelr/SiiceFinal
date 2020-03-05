using System;
using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddEmpleadosViewModel
    {
        public int id_Persona { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public long cedula { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-z A-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression("^[a-z A-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
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

        [Required]
        [Display(Name = "Estado civil")]
        public int id_ECivil { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        //[RegularExpression("^[a-zA-ZáÁéÉóÓÚú-0-9 ]+$", ErrorMessage = "Digitar unicamente letras")]
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

        [Required(ErrorMessage = "Debe seleccionar un tipo de usuario")]
        [Display(Name = "Tpo de usuario")]
        public int id_TipoUsu { get; set; }


        ////Rol 
        [Required(ErrorMessage = "Debe seleccionar un rol")]
        [Display(Name = "Rol")]
        public int id_Rol { get; set; }


        ////Empleado 
        [Required(ErrorMessage = "Debe seleccionar un departamento")]
        [Display(Name = "Departamento")]
        public int id_Departamento { get; set; }


        [Required]
        [Display(Name = "Cargo")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú  ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string cargo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Superior Inmediato")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string superior_Inmediato { get; set; }
    }
}
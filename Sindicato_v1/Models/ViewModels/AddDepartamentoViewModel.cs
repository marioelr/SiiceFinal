using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddDepartamentoViewModel
    {
        public int id_D { get; set; }

        [Required]
        //[MaxLength(50)]
        [Display(Name = "Departamento")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string depart { get; set; }

        [Required]
        [Display(Name = "Ubicación")]
        public string ubic { get; set; }

        [Required]
        [Display(Name = "Compañia")]
        public int id_Comp { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int est { get; set; }
    }
}

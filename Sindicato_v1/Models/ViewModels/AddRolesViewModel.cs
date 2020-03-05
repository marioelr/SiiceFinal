using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddRolesViewModel
    {
        public int id_R { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Rol")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string rol { get; set; }

        public int estado { get; set; }
    }
}
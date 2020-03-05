using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class AddECivilViewModel
    {
        public int id_ECiv { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Estado Civil")]
        [RegularExpression("^[a-zA-ZáÁéÉóÓÚú ]+$", ErrorMessage = "Digitar unicamente letras")]
        public string est_Civil { get; set; }
    }
}
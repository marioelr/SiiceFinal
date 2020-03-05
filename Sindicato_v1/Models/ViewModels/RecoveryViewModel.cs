using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class RecoveryViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo no válido")]
        public string Email { get; set; }
    }
}


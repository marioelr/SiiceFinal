using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class RecoveryPasswordViewModel
    {
        public string token { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Compare("Contraseña")]
        [Required]
        public string Contraseña2 { get; set; }
    }
}
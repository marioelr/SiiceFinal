using System;
using System.ComponentModel.DataAnnotations;

namespace Sindicato_v1.Models.ViewModels
{
    public class GestionesViewModel
    {
        /*Valores para empleados*/
        public int id_Emp { get; set; }
        public string nombre_emp { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string departamento { get; set; }

        /*Valores para gestiones*/
        [Required]
        [Display(Name = "Total Días de Vacaciones Disponibles")]
        public int tot_vac { get; set; }

        [Required]
        [Display(Name = "Cant. Ausencias Justificadas")]
        public int cant_au_jus { get; set; }

        [Required]
        [Display(Name = "Cant. Ausencias Injustificadas")]
        public int cant_au_injus { get; set; }

        [Required]
        [Display(Name = "Total Días de Vacaciones Solicitados")]
        public int vac_uti { get; set; }

        [Required]
        [Display(Name = "Cant. Días de Vacaciones Restantes")]
        public int vac_rest { get; set; }

        /*Valores para gestiones*/
        public int id_Gest { get; set; }

        [Required]
        [Display(Name = "Motivo de la gestión")]
        public string motivo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime f_inicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        public DateTime f_fin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la Ausencia")]
        public DateTime f_aus { get; set; }

        public int estado { get; set; }
        [Required]
        [Display(Name = "Tipo de Gestión")]
        public int id_TipoGes { get; set; }

        [Required]
        [Display(Name = "Cantidad Días de Vacaciones a Solicitar")]
        public int vac_solic { get; set; }

        [Required]
        [Display(Name = "Días a Ausentarse")]
        public int cant_aus { get; set; }


    }
}
using System;

namespace Sindicato_v1.Models.ViewModels
{
    public class SelectGestionesViewModel
    {
        public int id_Ges { get; set; }
        public string motivo_Ges { get; set; }
        public DateTime f_Inicio { get; set; }
        public DateTime f_Fin { get; set; }
        public int id_Emp { get; set; }
        public int t_Ges { get; set; }
        public int estado_Ges { get; set; }
    }
}
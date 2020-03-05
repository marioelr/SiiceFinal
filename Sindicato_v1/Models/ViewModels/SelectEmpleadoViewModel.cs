namespace Sindicato_v1.Models.ViewModels
{
    public class SelectEmpleadoViewModel
    {
        //Persona
        public int id_Persona { get; set; }
        public long cedula { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string Genero { get; set; }
        public string nacionalidad { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string correo_Electronico { get; set; }

        //Usuario
        public int id_Usuario { get; set; }
        public string contrasenia { get; set; }

        //Tipo usuario
        public int id_TipoUsu { get; set; }
        public string tipo_Usuario { get; set; }

        //Estado civil
        public int id_ECivil { get; set; }
        public string estado_Civil { get; set; }

        //Rol 
        public int id_Rol { get; set; }
        public string tipo_Rol { get; set; }

        //Empleado 
        //EM.CARGO, EM.SUPERIOR_INMEDIATO, EM.ESTADO
        public int id_Empleado { get; set; }
        public string cargo { get; set; }
        public string superior_Inmediato { get; set; }
    }
}
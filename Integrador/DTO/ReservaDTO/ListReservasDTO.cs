namespace Integrador.DTO.ReservaDTO
{
    public class ListReservasDTO
    {
        public DateTime Fecha { get; set; }
        public int Estado { get; set; } // Cambiado a int
        public int UsId { get; set; }
        public string UsNombre { get; set; } // Nombre de usuario
        public string UsApellido { get; set; } // Apellido de usuario
        public int DocId { get; set; }
        public string DocNombre { get; set; } // Nombre del doctor
        public string DocApellido { get; set; } // Apellido del doctor
        public int AtId { get; set; }
        public string AtDescripcion { get; set; } // Descripción del tipo de atención
        public int CliId { get; set; }
        public string CliNombre { get; set; } // Nombre de la clínica
        public string CliDireccion { get; set; } // Dirección de la clínica
    }
}

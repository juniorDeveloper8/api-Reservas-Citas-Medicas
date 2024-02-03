namespace Integrador.DTO.FichaDTO
{
    public class ListFichaDTO
    {
        public int FichaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }

        public int? UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioTipoDocumento { get; set; }
        public string UsuarioDni { get; set; }

        public int? DoctorId { get; set; }
        public string DoctorNombre { get; set; }
        public string DoctorApellido { get; set; }
        public string DoctorTipoDocumento { get; set; }
        public string DoctorDni { get; set; }
    }
}

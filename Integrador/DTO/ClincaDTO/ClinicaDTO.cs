namespace Integrador.DTO.ClincaDTO
{
    // Define la clase del DTO para la entidad de Clínica
    public class ClinicaDTO
    {
        public int Id { get; set; }
        public string ClinicaNombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
        //public byte Estado { get; set; }
    }
    public class CrearClinicaDTO
    {
        public string ClinicaNombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
    }
    public class ActualizarClinicaDTO
    {
        public int Id { get; set; }
        public string ClinicaNombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
    }
    public class EliminarClinicaDTO
    {
        public int Id { get; set; }
    }

}

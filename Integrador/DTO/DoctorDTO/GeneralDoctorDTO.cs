namespace Integrador.DTO.DoctorDTO
{
    public class DoctorDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Psw { get; set; }
        public string Celular { get; set; }
    }
    public class GeneralDoctorDTO

    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Psw { get; set; }
        public string Celular { get; set; }
        public byte Estado { get; set; }
        public int? RolUser { get; set; }
    }

    public class DeleteDoctorDTO
    {
        public int Id { get; set; }
    }
}

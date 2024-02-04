namespace Integrador.DTO.UserDTO
{
   public class ListPacienteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Celular { get; set; }
    }
    public class GeneralUserDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Psw { get; set; }
        public string Celular { get; set; }

        public int RolUser { get; set; }
    }

    public class USerDTOID
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string TipoDocumento { get; set; } = null!;

        public string Dni { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Psw { get; set; } = null!;

        public string Celular { get; set; } = null!;
    }
}

namespace Integrador.DTO
{
    public class InsertarUserDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string TipoDocumento { get; set; } = null!;

        public string Dni { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Psw { get; set; } = null!;

        public string Celular { get; set; } = null!;

        public byte Estado { get; set; }
    }
}

namespace Integrador.DTO.especialidad
{
    public class EspecialidadDTO
    {
        public int Id { get; set; }
        public string ENombre { get; set; }
        public string EDescripcion { get; set; }
        public string EArea { get; set; }
        public string ECodigo { get; set; }
        public byte Estado { get; set; }

    }

    public class DeleteEspecialidadDTO
    {
        public int Id { get; set; }
        public string ENombre { get; set; }
        public string EDescripcion { get; set; }
        public string EArea { get; set; }
        public string ECodigo { get; set; }
        public byte Estado { get; set; }


    }
}

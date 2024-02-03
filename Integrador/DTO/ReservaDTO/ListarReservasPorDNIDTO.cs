namespace Integrador.DTO.ReservaDTO
{
    public class ListarReservasPorDNIDTO
    {
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public int UsId { get; set; }
        public string UsNombre { get; set; }
        public string UsApellido { get; set; }
        public int DocId { get; set; }
        public string DocNombre { get; set; }
        public string DocApellido { get; set; }
        public int AtId { get; set; }
        public string AtDescripcion { get; set; }
        public int CliId { get; set; }
        public string CliNombre { get; set; }
        public string CliDireccion { get; set; }
    }
}

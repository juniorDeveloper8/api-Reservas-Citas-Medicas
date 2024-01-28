namespace Integrador.DTO.ReservaDTO
{
    public class ListReservasDTO
    {
        public DateTime Fecha { get; set; }

        public byte Estado { get; set; }

        public int UsId { get; set; }

        public int DocId { get; set; }

        public int AtId { get; set; }

        public int CliId { get; set; }
    }
}

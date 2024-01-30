using Integrador.Models;

namespace Integrador.DTO.ReservaDTO
{
    public class InsertReservaDTO
    {
        public DateTime Fecha { get; set; }

        public string Sintomas { get; set; } = null!;

        public byte Estado { get; set; }

        public int UsId { get; set; }

        public int DocId { get; set; }

        public int AtId { get; set; }

        public int CliId { get; set; }

        public int EspecialidadId { get; set; }

    }
}

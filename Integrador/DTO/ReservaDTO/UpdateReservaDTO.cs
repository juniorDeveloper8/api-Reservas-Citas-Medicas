using Integrador.Models;

namespace Integrador.DTO.ReservaDTO
{
    public class UpdateReservaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int AtId { get; set; }
        public int CliId { get; set; }

    }
}

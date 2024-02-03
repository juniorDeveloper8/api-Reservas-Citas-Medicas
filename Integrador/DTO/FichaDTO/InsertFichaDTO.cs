namespace Integrador.DTO.FichaDTO
{
    public class InsertarFichaDTO
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int UsuId { get; set; }
        public int DocId { get; set; }
    }
}

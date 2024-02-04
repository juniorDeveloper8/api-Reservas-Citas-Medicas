using Integrador.DTO.ClincaDTO;
using Integrador.Models;

namespace Integrador.Logica.ClinicaService
{
    public class ListClinicaService
    {
        private readonly DbIntegradorContext _context;

        public ListClinicaService(DbIntegradorContext context)
        {
            _context = context;
        }
        public List<ClinicaDTO> ListarClinicas()
        {
            try
            {
                var clinicas = _context.Clinicas
    .Where(c => c.Estado == 1) // Por ejemplo, asumiendo que 1 representa el estado activo
    .Select(c => new ClinicaDTO
    {
        Id = c.Id,
        ClinicaNombre = c.ClinicaNombre,
        Direccion = c.Direccion,
        Ruc = c.Ruc
    })
    .ToList();

                return clinicas;
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí si es necesario
                Console.WriteLine($"Error al listar clínicas: {ex.Message}");
                throw;
            }
        

    }
}
}

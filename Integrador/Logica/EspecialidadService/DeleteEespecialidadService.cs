using Integrador.Models;
using Microsoft.EntityFrameworkCore;


namespace Integrador.Logica.EspecialidadService
{
    public class DeleteEspecialidadService
    {
        private readonly DbIntegradorContext _context;

        public DeleteEspecialidadService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task DeleteEspecialidadAsync(int especialidadId)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC [dbo].[deleteEspecialidad] {especialidadId}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la especialidad.", ex);
            }
        }
    }
}

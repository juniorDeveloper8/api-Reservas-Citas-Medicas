using Integrador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Integrador.Logica.ClinicaService
{
    public class DeleteClinicaService
    {
        private readonly DbIntegradorContext _context;

        public DeleteClinicaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> EliminarClinica(int id)
        {
            try
            {
                var clinica = await _context.Clinicas.FindAsync(id);

                if (clinica == null)
                    return false;

                _context.Database.ExecuteSqlInterpolated($"EXEC DeleteClinica {id}");

                return true; // Si la eliminación es exitosa
            }
            catch (Exception)
            {
                // Manejar errores aquí, por ejemplo, loggear el error
                return false; // Si hay un error en la eliminación
            }
        }
    }
}

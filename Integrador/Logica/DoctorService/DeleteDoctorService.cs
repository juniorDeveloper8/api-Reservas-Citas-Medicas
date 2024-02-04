using Integrador.DTO.DoctorDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Integrador.Logica.DoctorService
{
    public class DeleteDoctorService
    {
        private readonly DbIntegradorContext _context;

        public DeleteDoctorService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> EliminarDoctor(DeleteDoctorDTO deleteDoctorDTO)
        {
            try
            {
                var idParam = new SqlParameter("@id", deleteDoctorDTO.Id);

                await _context.Database.ExecuteSqlRawAsync("EXEC DeleteDoctor @id", idParam);

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

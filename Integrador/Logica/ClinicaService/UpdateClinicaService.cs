using Integrador.DTO.ClincaDTO;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Logica.ClinicaService
{
    public class UpdateClinicaService
    {
        private readonly DbIntegradorContext _context;

        public UpdateClinicaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarClinica(ActualizarClinicaDTO clinicaDTO)
        {
            try
            {
                var clinica = await _context.Clinicas.FindAsync(clinicaDTO.Id);

                if (clinica == null)
                    return false;

                clinica.ClinicaNombre = clinicaDTO.ClinicaNombre;
                clinica.Direccion = clinicaDTO.Direccion;
                clinica.Ruc = clinicaDTO.Ruc;

                _context.Entry(clinica).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true; // Si la actualización es exitosa
            }
            catch (Exception)
            {
                // Manejar errores aquí, por ejemplo, loggear el error
                return false; // Si hay un error en la actualización
            }
        }
    }
}

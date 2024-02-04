using Integrador.DTO.ClincaDTO;
using Integrador.Models;

namespace Integrador.Logica.ClinicaService
{
    public class InsertClinicaService
    {
        private readonly DbIntegradorContext _context;

        public InsertClinicaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarClinica(CrearClinicaDTO clinicaDTO)
        {
            try
            {
                var nuevaClinica = new Clinica
                {
                    ClinicaNombre = clinicaDTO.ClinicaNombre,
                    Direccion = clinicaDTO.Direccion,
                    Ruc = clinicaDTO.Ruc,
                    Estado = 1 // Estado por defecto activo
                };

                _context.Clinicas.Add(nuevaClinica);
                await _context.SaveChangesAsync();

                return true; // Si la inserción es exitosa
            }
            catch (Exception)
            {
                // Manejar errores aquí, por ejemplo, loggear el error
                return false; // Si hay un error en la inserción
            }
        }
    }
}

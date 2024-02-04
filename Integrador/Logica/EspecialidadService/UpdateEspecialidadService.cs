using Integrador.DTO.especialidad;
using Integrador.Models;

namespace Integrador.Logica
{
    public class UpdateEspecialidadService
    {
        private readonly DbIntegradorContext _context;

        public UpdateEspecialidadService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarEspecialidadAsync(int id, EspecialidadDTO especialidadDTO)
        {
            try
            {
                var especialidad = await _context.Especialidads.FindAsync(id);

                if (especialidad == null)
                {
                    return false; // Si no se encuentra la especialidad
                }

                // Actualizar los campos de la especialidad con los valores del DTO
                especialidad.ENombre = especialidadDTO.ENombre;
                especialidad.EDescripcion = especialidadDTO.EDescripcion;
                especialidad.EArea = especialidadDTO.EArea;
                especialidad.ECodigo = especialidadDTO.ECodigo;

                await _context.SaveChangesAsync();

                return true; // Si la actualización fue exitosa
            }
            catch (Exception)
            {
                return false; // Si hubo un error al actualizar
            }
        }
    }
}

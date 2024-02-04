using Integrador.DTO.especialidad;
using Integrador.Models;

public class InsertEspecialidadService
{
    private readonly DbIntegradorContext _context;

    public InsertEspecialidadService(DbIntegradorContext context)
    {
        _context = context;
    }

    public async Task<bool> InsertarEspecialidad(EspecialidadDTO especialidadDTO)
    {
        if (especialidadDTO == null)
        {
            throw new ArgumentNullException(nameof(especialidadDTO), "Los datos de la especialidad son nulos.");
        }

        try
        {
            // Crear una nueva instancia de Especialidad y asignar valores desde el DTO
            var nuevaEspecialidad = new Especialidad
            {
                ENombre = especialidadDTO.ENombre,
                EDescripcion = especialidadDTO.EDescripcion,
                EArea = especialidadDTO.EArea,
                ECodigo = especialidadDTO.ECodigo,
                Estado = 1
            };

            // Agregar la nueva especialidad al contexto y guardar cambios en la base de datos
            _context.Especialidads.Add(nuevaEspecialidad);
            await _context.SaveChangesAsync();

            return true; // La inserción fue exitosa
        }
        catch (Exception)
        {
            return false; // La inserción falló
        }

    }
}

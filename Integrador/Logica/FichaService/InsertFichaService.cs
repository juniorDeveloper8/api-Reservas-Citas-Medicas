using Integrador.DTO.FichaDTO;
using Integrador.Models;

namespace Integrador.Logica.FichaServices
{
    public class InsertFichaService
    {
        private readonly DbIntegradorContext _context;

        public InsertFichaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarFicha(InsertarFichaDTO fichaDTO)
        {
            try
            {
                // Crear un nuevo objeto de tipo ficha y asignar los valores del DTO
                var nuevaFicha = new Ficha
                {
                    Descripcion = fichaDTO.Descripcion,
                    Fecha = fichaDTO.Fecha,
                    Hora = fichaDTO.Hora,
                    UsuId = fichaDTO.UsuId,
                    DocId = fichaDTO.DocId
                };

                // Agregar la nueva ficha al contexto
                _context.Fichas.Add(nuevaFicha);

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return false;
            }
        }
    }
}

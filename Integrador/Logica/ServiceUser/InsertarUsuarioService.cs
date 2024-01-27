using System.Threading.Tasks;
using Integrador.DTO;
using Integrador.Models;
using Integrador.Persistencia;

namespace Integrador.Services
{
    public class InsertarUsuarioService
    {
        private readonly DbIntegradorContext _context;

        public InsertarUsuarioService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarUsuario(RegistroUsersDTO usuarioDTO)
        {
            try
            {
                // Crear una instancia de Usuario utilizando los datos del DTO
                var nuevoUsuario = new Registro
                {
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    TipoDocumento = usuarioDTO.TipoDocumento,
                    Dni = usuarioDTO.Dni,
                    Correo = usuarioDTO.Correo,
                    Psw = usuarioDTO.Psw,
                    Celular = usuarioDTO.Celular
                };

                // Agregar el nuevo usuario al contexto
                _context.Registros.Add(nuevoUsuario);

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

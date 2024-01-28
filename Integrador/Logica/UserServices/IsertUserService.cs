using Integrador.DTO.UserDTO;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Services
{
    public class InsertarUsuarioService
    {
        private readonly DbIntegradorContext _context;

        public InsertarUsuarioService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarUsuario(GeneralUserDTO usuarioDTO)
        {
            try
            {
                // Llamar al procedimiento almacenado para insertar un nuevo usuario
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.InsertarUsuario @nombre, @apellido, @tipoDocumento, @dni, @correo, @psw, @celular, @username",
                    new SqlParameter("@nombre", usuarioDTO.Nombre),
                    new SqlParameter("@apellido", usuarioDTO.Apellido),
                    new SqlParameter("@tipoDocumento", usuarioDTO.TipoDocumento),
                    new SqlParameter("@dni", usuarioDTO.Dni),
                    new SqlParameter("@correo", usuarioDTO.Correo),
                    new SqlParameter("@username", usuarioDTO.Username),
                    new SqlParameter("@psw", usuarioDTO.Psw),
                    new SqlParameter("@celular", usuarioDTO.Celular)
                );

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

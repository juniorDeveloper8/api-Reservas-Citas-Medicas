using Integrador.DTO.UserDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.UserServices
{
    public class UpdateUserService
    {
        private readonly DbIntegradorContext _context;

        public UpdateUserService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<string> ActualizarUsuario(int id, USerDTOID usuarioDTO)
        {
            try
            {
                var userIdParam = new SqlParameter("@UserID", SqlDbType.Int) { Value = id };
                var nombreParam = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = usuarioDTO.Nombre };
                var apellidoParam = new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = usuarioDTO.Apellido };
                var tipoDocumentoParam = new SqlParameter("@TipoDocumento", SqlDbType.VarChar) { Value = usuarioDTO.TipoDocumento };
                var dniParam = new SqlParameter("@DNI", SqlDbType.VarChar) { Value = usuarioDTO.Dni };
                var correoParam = new SqlParameter("@Correo", SqlDbType.VarChar) { Value = usuarioDTO.Correo };
                var usernameParam = new SqlParameter("@Username", SqlDbType.VarChar) { Value = usuarioDTO.Username };
                var passwordParam = new SqlParameter("@Password", SqlDbType.VarChar) { Value = usuarioDTO.Psw };
                var celularParam = new SqlParameter("@Celular", SqlDbType.VarChar) { Value = usuarioDTO.Celular };

                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC ActualizarUsuario @UserID, @Nombre, @Apellido, @TipoDocumento, @DNI, @Correo, @Username, @Password, @Celular",
                    userIdParam, nombreParam, apellidoParam, tipoDocumentoParam, dniParam, correoParam, usernameParam, passwordParam, celularParam);

                return result > 0 ? "Usuario actualizado correctamente" : "No se pudo actualizar el usuario";
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return $"Error al actualizar usuario: {ex.Message}";
            }
        }

    }
}


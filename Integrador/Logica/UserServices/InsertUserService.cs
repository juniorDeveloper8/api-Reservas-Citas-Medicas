using Integrador.DTO.UserDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Logica.UserServices
{
    public class InsertUserService
    {
        private readonly DbIntegradorContext _context;

        public InsertUserService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarUsuario(GeneralUserDTO usuarioDTO)
        {
            try
            {
                // var prueba= await _prueba.GetProcedures().;
                // Llamar al procedimiento almacenado para insertar un nuevo usuario
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.InsertarUsuario @nombre, @apellido, @tipoDocumento, @dni, @correo, @username, @psw, @celular, @RolUser", // Agrega @RolUser a la cadena de SQL
                    new SqlParameter("@nombre", usuarioDTO.Nombre),
                    new SqlParameter("@apellido", usuarioDTO.Apellido),
                    new SqlParameter("@tipoDocumento", usuarioDTO.TipoDocumento),
                    new SqlParameter("@dni", usuarioDTO.Dni),
                    new SqlParameter("@correo", usuarioDTO.Correo),
                    new SqlParameter("@username", usuarioDTO.Username),
                    new SqlParameter("@psw", usuarioDTO.Psw),
                    new SqlParameter("@celular", usuarioDTO.Celular),
                    new SqlParameter("@RolUser", usuarioDTO.RolUser) // Asegúrate de incluir el parámetro @RolUser aquí
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


using Integrador.DTO.UserDTO;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.ServiceUser
{
    public class UpdateUser
    {
        private readonly DbIntegradorContext _context;

        public UpdateUser(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<string> ActualizarUsuario(int id, GeneralUserDTO usuarioDTO)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "ActualizarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario_id", SqlDbType.Int) { Value = id });
                    command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar) { Value = usuarioDTO.Nombre });
                    command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar) { Value = usuarioDTO.Apellido });
                    command.Parameters.Add(new SqlParameter("@tipoDocumento", SqlDbType.VarChar) { Value = usuarioDTO.TipoDocumento });
                    command.Parameters.Add(new SqlParameter("@dni", SqlDbType.VarChar) { Value = usuarioDTO.Dni });
                    command.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar) { Value = usuarioDTO.Correo });
                    command.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar) { Value = usuarioDTO.Username });
                    command.Parameters.Add(new SqlParameter("@psw", SqlDbType.VarChar) { Value = usuarioDTO.Psw });
                    command.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar) { Value = usuarioDTO.Celular });

                    var result = await command.ExecuteScalarAsync();
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return ex.Message;
            }
        }
    }
}

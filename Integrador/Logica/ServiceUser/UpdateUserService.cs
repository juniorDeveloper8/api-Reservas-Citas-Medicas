using Integrador.DTO;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Integrador.Logica.ServiceUser
{
    public class UpdateUserService
    {
        private readonly DbIntegradorContext _context;

        public UpdateUserService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<string> ActualizarUsuario(int id, ListUsersDTO usuarioDTO)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "sp_ActualizarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario_id", SqlDbType.Int) { Value = id });
                    command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 100) { Value = usuarioDTO.Nombre });
                    command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar, 100) { Value = usuarioDTO.Apellido });
                    command.Parameters.Add(new SqlParameter("@tipoDocumento", SqlDbType.NVarChar, 100) { Value = usuarioDTO.TipoDocumento });
                    command.Parameters.Add(new SqlParameter("@dni", SqlDbType.NVarChar, 20) { Value = usuarioDTO.Dni });
                    command.Parameters.Add(new SqlParameter("@correo", SqlDbType.NVarChar, 100) { Value = usuarioDTO.Correo });
                    command.Parameters.Add(new SqlParameter("@psw", SqlDbType.NVarChar, 100) { Value = usuarioDTO.Psw });
                    command.Parameters.Add(new SqlParameter("@celular", SqlDbType.NVarChar, 20) { Value = usuarioDTO.Celular });

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

using Integrador.DTO;
using Integrador.Models;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.ServiceUser
{
    public class ListarUsuariosService
    {
        private readonly DbIntegradorContext _context;

        public ListarUsuariosService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistroUsersDTO>> ListarUsuarios()
        {
            try
            {
                var usuarios = new List<RegistroUsersDTO>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "sp_GestionarUsuarios";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@accion", SqlDbType.NVarChar) { Value = "LISTAR" });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new RegistroUsersDTO
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                TipoDocumento = reader.GetString(reader.GetOrdinal("tipoDocumento")),
                                Dni = reader.GetString(reader.GetOrdinal("dni")),
                                Correo = reader.GetString(reader.GetOrdinal("correo")),
                                Psw = reader.GetString(reader.GetOrdinal("psw")),
                                Celular = reader.GetString(reader.GetOrdinal("celular"))
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return null;
            }
        }
        //obtener por id
        public async Task<RegistroUsersDTO> ObtenerRegistroPorId(int id)
        {
            try
            {
                RegistroUsersDTO registro = null; // Cambiar el tipo de la variable registro

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "sp_ObtenerUsuarioPorId"; // Cambiar el nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario_id", SqlDbType.Int) { Value = id });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            registro = new RegistroUsersDTO // Cambiar el tipo de objeto
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                TipoDocumento = reader.GetString(reader.GetOrdinal("tipoDocumento")),
                                Dni = reader.GetString(reader.GetOrdinal("dni")),
                                Correo = reader.GetString(reader.GetOrdinal("correo")),
                                Psw = reader.GetString(reader.GetOrdinal("psw")),
                                Celular = reader.GetString(reader.GetOrdinal("celular"))
                            };
                        }
                    }
                }

                return registro;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return null;
            }
        }



    }

}


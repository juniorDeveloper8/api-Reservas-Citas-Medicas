using Integrador.DTO.ReservaDTO;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.ReservaServices
{
    public class ListReservaXDNIService
    {
        private readonly DbIntegradorContext _context;

        public ListReservaXDNIService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<List<ListarReservasPorDNIDTO>> ListarReservasPorDNI(int dni)
        {
            try
            {
                var reservas = new List<ListarReservasPorDNIDTO>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "ListarReservaPorDNI";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@DNI", SqlDbType.Int) { Value = dni });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reservas.Add(new ListarReservasPorDNIDTO
                            {
                                Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                Estado = reader.GetInt32(reader.GetOrdinal("estado")),
                                UsId = reader.GetInt32(reader.GetOrdinal("usId")),
                                UsNombre = reader.GetString(reader.GetOrdinal("usNombre")),
                                UsApellido = reader.GetString(reader.GetOrdinal("usApellido")),
                                DocId = reader.GetInt32(reader.GetOrdinal("docId")),
                                DocNombre = reader.GetString(reader.GetOrdinal("docNombre")),
                                DocApellido = reader.GetString(reader.GetOrdinal("docApellido")),
                                AtId = reader.GetInt32(reader.GetOrdinal("atId")),
                                AtDescripcion = reader.GetString(reader.GetOrdinal("atDescripcion")),
                                CliId = reader.GetInt32(reader.GetOrdinal("cliId")),
                                CliNombre = reader.GetString(reader.GetOrdinal("cliNombre")),
                                CliDireccion = reader.GetString(reader.GetOrdinal("cliDireccion"))
                            });
                        }
                    }
                }

                return reservas;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return null;
            }
        }
    }
}

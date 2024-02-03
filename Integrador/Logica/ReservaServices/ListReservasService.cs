using Integrador.DTO.ReservaDTO;
using Integrador.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Integrador.Logica.ReservaServices
{
    public class ListReservasService
    {
        private readonly DbIntegradorContext _context;

        public ListReservasService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<List<ListReservasDTO>> ListarReservas()
        {
            try
            {
                var reservas = new List<ListReservasDTO>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "ListarReserva";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var estado = reader.GetInt32(reader.GetOrdinal("estado"));

                            // Verificar si el estado es igual a 1 antes de agregar la reserva
                            if (estado == 1)
                            {
                                reservas.Add(new ListReservasDTO
                                {
                                    Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                    Estado = estado,
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

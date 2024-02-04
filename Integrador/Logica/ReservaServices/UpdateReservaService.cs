using Integrador.DTO.ReservaDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.ReservaServices
{
    public class UpdateReservaService
    {
        private readonly DbIntegradorContext _context;

        public UpdateReservaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarReserva(int reservaId, UpdateReservaDTO reservaDTO)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "ActualizarReserva";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ReservaID", SqlDbType.Int) { Value = reservaId });
                    command.Parameters.Add(new SqlParameter("@NuevaFecha", SqlDbType.DateTime) { Value = reservaDTO.Fecha });
                    command.Parameters.Add(new SqlParameter("@NuevoTipoAtencionID", SqlDbType.Int) { Value = reservaDTO.AtId });
                    command.Parameters.Add(new SqlParameter("@NuevaClinicaID", SqlDbType.Int) { Value = reservaDTO.CliId });

                    await command.ExecuteNonQueryAsync();
                }

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

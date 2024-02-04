using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Integrador.Logica.ReservaServices
{
    public class DeleteReservaService
    {
        private readonly DbIntegradorContext _context;

        public DeleteReservaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> EliminarReserva(int reservaId)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "DeleteReserva";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ReservaID", SqlDbType.Int) { Value = reservaId });

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

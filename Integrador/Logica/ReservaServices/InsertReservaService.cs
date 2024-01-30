using Integrador.DTO.ReservaDTO;
using Integrador.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Integrador.Logica.ReservaServices
{
    public class InsertReservaService
    {
        private readonly DbIntegradorContext _context;

        public InsertReservaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarReserva(InsertReservaDTO reservaDTO)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    await _context.Database.OpenConnectionAsync();

                    command.CommandText = "InsertarReserva";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = reservaDTO.Fecha });
                    command.Parameters.Add(new SqlParameter("@Sintomas", SqlDbType.VarChar) { Value = reservaDTO.Sintomas });
                    command.Parameters.Add(new SqlParameter("@Estado", SqlDbType.TinyInt) { Value = reservaDTO.Estado });
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int) { Value = reservaDTO.UsId });
                    command.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.Int) { Value = reservaDTO.DocId });
                    command.Parameters.Add(new SqlParameter("@TipoAtencionID", SqlDbType.Int) { Value = reservaDTO.AtId });
                    command.Parameters.Add(new SqlParameter("@ClinicaID", SqlDbType.Int) { Value = reservaDTO.CliId });
                    command.Parameters.Add(new SqlParameter("@EspecialidadID", SqlDbType.Int) { Value = reservaDTO.EspecialidadId });

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

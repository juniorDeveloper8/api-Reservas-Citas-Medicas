using Integrador.DTO.FichaDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Logica.FichaServices
{
    public class ListFichaService
    {
        private readonly DbIntegradorContext _context;

        public ListFichaService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<List<ListFichaDTO>> ObtenerListadoFichasDoctoresUsuarios()
        {
            var fichas = new List<ListFichaDTO>();

            await using var connection = new SqlConnection(_context.Database.GetConnectionString());
            await using var command = connection.CreateCommand();
            command.CommandText = "EXEC dbo.ListarFichasDoctoresUsuarios";

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var ficha = new ListFichaDTO
                {
                    FichaId = reader.GetInt32(0),
                    Descripcion = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Fecha = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                    Hora = reader.IsDBNull(3) ? null : reader.GetTimeSpan(3),
                    UsuarioId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                    UsuarioNombre = reader.IsDBNull(5) ? null : reader.GetString(5),
                    UsuarioApellido = reader.IsDBNull(6) ? null : reader.GetString(6),
                    UsuarioTipoDocumento = reader.IsDBNull(7) ? null : reader.GetString(7),
                    UsuarioDni = reader.IsDBNull(8) ? null : reader.GetString(8),
                    DoctorId = reader.IsDBNull(9) ? null : reader.GetInt32(9),
                    DoctorNombre = reader.IsDBNull(10) ? null : reader.GetString(10),
                    DoctorApellido = reader.IsDBNull(11) ? null : reader.GetString(11),
                    DoctorTipoDocumento = reader.IsDBNull(12) ? null : reader.GetString(12),
                    DoctorDni = reader.IsDBNull(13) ? null : reader.GetString(13)
                };

                fichas.Add(ficha);
            }

            return fichas;
        }
    }
}

using Integrador.DTO;
using Integrador.DTO.DoctorDTO;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Integrador.Logica.DoctorService
{
    public class UpdateDoctorService
    {
        private readonly DbIntegradorContext _context;

        public UpdateDoctorService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDoctor(GeneralDoctorDTO doctorDTO)
        {
            try
            {
                var idParam = new SqlParameter("@id", doctorDTO.Id);
                var nombreParam = new SqlParameter("@nombre", doctorDTO.Nombre);
                var apellidoParam = new SqlParameter("@apellido", doctorDTO.Apellido);
                var tipoDocumentoParam = new SqlParameter("@tipoDocumento", doctorDTO.TipoDocumento);
                var dniParam = new SqlParameter("@dni", doctorDTO.Dni);
                var correoParam = new SqlParameter("@correo", doctorDTO.Correo);
                var usernameParam = new SqlParameter("@username", doctorDTO.Username);
                var pswParam = new SqlParameter("@psw", doctorDTO.Psw);
                var celularParam = new SqlParameter("@celular", doctorDTO.Celular);

                await _context.Database.ExecuteSqlRawAsync("EXEC ActualizarDoctor @id, @nombre, @apellido, @tipoDocumento, @dni, @correo, @username, @psw, @celular",
                    idParam, nombreParam, apellidoParam, tipoDocumentoParam, dniParam, correoParam, usernameParam, pswParam, celularParam);

                return true; // Si la actualización es exitosa
            }
            catch (Exception)
            {
                // Manejar errores aquí, por ejemplo, loggear el error
                return false; // Si hay un error en la actualización
            }
        }
    }
}

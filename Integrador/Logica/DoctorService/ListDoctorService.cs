using Integrador.DTO.DoctorDTO;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Logica.DoctorService
{
    public class ListDoctorService
    {
        private readonly DbIntegradorContext _context;

        public ListDoctorService(DbIntegradorContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorDTO>> ObtenerDoctores()
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.RolUser == 1)
                .ToListAsync();

            var doctoresDTO = usuarios.Select(usuario => new DoctorDTO
            {
                
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                Dni = usuario.Dni,
                Correo = usuario.Correo,
                Username = usuario.Username,
                Psw = usuario.Psw,
                Celular = usuario.Celular
            }).ToList();

            return doctoresDTO;
        }
    }
}

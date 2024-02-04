using Integrador.DTO.UserDTO;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Logica.UserServices
{
    public class UserServices
    {
        private readonly DbIntegradorContext _context;

        public UserServices(DbIntegradorContext context)
        {
            _context = context;
        }
        public async Task<List<ListPacienteDTO>> ListarUsuarios()
        {
            // Llama al procedimiento almacenado para obtener los usuarios con rol igual a 2
            var usuariosConRolDos = await _context.Usuarios
                .FromSqlRaw($"EXEC ListarUsuarios")
                .ToListAsync();

            // Si no se encuentra ningún usuario con ese ID, devuelve null
            if (usuariosConRolDos == null || usuariosConRolDos.Count == 0)
                return null;

            // Mapea los resultados a DTOs ListPacienteDTO
            var listPacientesDTO = usuariosConRolDos.Select(u => new ListPacienteDTO
            {
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                TipoDocumento = u.TipoDocumento,
                Dni = u.Dni,
                Correo = u.Correo,
                Username = u.Username,
                Celular = u.Celular
            }).ToList();

            return listPacientesDTO;
        }

        //obtener el usurio por id
        public USerDTOID GetUserById(int userId)
        {
            // Llama al procedimiento almacenado y filtra por el ID del usuario
            var usuario = _context.Usuarios
                .FromSqlInterpolated($"EXEC ListarUsuarioPorID {userId}")
                .ToList()  // Forzar ejecución en el lado del cliente
                .FirstOrDefault();

            // Si no se encuentra ningún usuario con ese ID, devuelve null
            if (usuario == null)
                return null;

            // Convierte la entidad Usuario a un DTO GeneralUserDTO
            var usuarioDTO = new USerDTOID
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                Dni = usuario.Dni,
                Correo = usuario.Correo,
                Username = usuario.Username,
                Psw = usuario.Psw,
                Celular = usuario.Celular
            };

            return usuarioDTO;
        }

        // listar por cedula o nombre 
        public List<GeneralUserDTO> GetUsersByNameAndIdNumber(string nombre, string cedula)
        {
            // Llama al procedimiento almacenado y filtra por nombre y cédula
            var usuarios = _context.Usuarios
                .FromSqlInterpolated($"EXEC ListarUsuarioPorNombreYCedula {nombre}, {cedula}")
                .ToList();

            // Convierte las entidades Usuario a DTO GeneralUserDTO
            var usuariosDTO = usuarios.Select(usuario => new GeneralUserDTO
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

            return usuariosDTO;
        }
    }
}

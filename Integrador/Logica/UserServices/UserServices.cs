using Integrador.DTO.UserDTO;
using Integrador.Models;
using Integrador.Persistencia; // Asegúrate de importar el contexto de Entity Framework
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

        public async Task<List<GeneralUserDTO>> ListarUsuarios()
        {
            // Llama al procedimiento almacenado y mapea los resultados a entidades Usuario
            List<Usuario> usuarios = await _context.Usuarios.FromSqlInterpolated($"EXEC ListarUsuarios").ToListAsync();

            // Convierte las entidades Usuario a DTOs GeneralUserDTO
            List<GeneralUserDTO> usuariosDTO = new List<GeneralUserDTO>();
            foreach (var usuario in usuarios)
            {
                GeneralUserDTO userDTO = new GeneralUserDTO
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
                usuariosDTO.Add(userDTO);
            }

            return usuariosDTO;
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

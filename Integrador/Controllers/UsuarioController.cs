using Integrador.DTO;
using Integrador.Logica.ServiceUser;
using Integrador.Models;
using Integrador.Services;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ListarUsuariosService _listarUsuariosService;
        private readonly InsertarUsuarioService _insertarUsuarioService;
        private readonly UpdateUserService _updateUser;
        public UsuarioController(ListarUsuariosService listarUsuariosService, InsertarUsuarioService insertarUsuarioService, UpdateUserService updateUser)
        {
            _listarUsuariosService = listarUsuariosService;
            _insertarUsuarioService = insertarUsuarioService;
            _updateUser = updateUser;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListUsersDTO>>> GetRegistros()
        {
            var registros = await _listarUsuariosService.ListarUsuarios();

            if (registros == null)
            {
                return NotFound();
            }

            return Ok(registros);
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListUsersDTO>> GetUsuario(int id)
        {
            var usuario = await _listarUsuariosService.ObtenerRegistroPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<bool>> PostUsuario(InsertarUserDTO usuarioDTO)
        {
            var resultado = await _insertarUsuarioService.InsertarUsuario(usuarioDTO);

            if (!resultado)
            {
                return Problem("Error al insertar el usuario en la base de datos.");
            }

            return Ok(true);
        }

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, ListUsersDTO usuarioDTO)
        {
            var resultado = await _updateUser.ActualizarUsuario(id, usuarioDTO);

            if (resultado.Equals("Usuario actualizado correctamente."))
            {
                return NoContent();
            }
            else if (resultado.Equals("No se encontró ningún usuario con el ID especificado."))
            {
                return NotFound();
            }
            else
            {
                return Problem(resultado);
            }
        }
    }
}




//        // DELETE: api/Registroes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteRegistro(int id)
//        {
//            if (_context.Registros == null)
//            {
//                return NotFound();
//            }
//            var registro = await _context.Registros.FindAsync(id);
//            if (registro == null)
//            {
//                return NotFound();
//            }

//            _context.Registros.Remove(registro);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool RegistroExists(int id)
//        {
//            return (_context.Registros?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}

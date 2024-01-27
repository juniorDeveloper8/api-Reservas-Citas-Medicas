using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Integrador.Models;
using Integrador.Persistencia;
using Integrador.Logica.ServiceUser;
using Integrador.DTO;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ListarUsuariosService _listarUsuariosService;

        public UsuarioController(ListarUsuariosService listarUsuariosService)
        {
            _listarUsuariosService = listarUsuariosService;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroUsersDTO>>> GetRegistros()
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
        public async Task<ActionResult<RegistroUsersDTO>> GetUsuario(int id)
        {
            var usuario = await _listarUsuariosService.ObtenerRegistroPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


    }


}


//        // PUT: api/Registroes/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutRegistro(int id, Registro registro)
//        {
//            if (id != registro.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(registro).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!RegistroExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Registroes
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Registro>> PostRegistro(Registro registro)
//        {
//          if (_context.Registros == null)
//          {
//              return Problem("Entity set 'DbIntegradorContext.Registros'  is null.");
//          }
//            _context.Registros.Add(registro);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetRegistro", new { id = registro.Id }, registro);
//        }

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

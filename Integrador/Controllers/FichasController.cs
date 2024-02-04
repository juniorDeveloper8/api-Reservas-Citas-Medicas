using Integrador.DTO.FichaDTO;
using Integrador.Logica.FichaServices;
using Integrador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichasController : ControllerBase
    {
        private readonly DbIntegradorContext _context;
        private readonly ListFichaService _listFichaService;
        private readonly InsertFichaService _insertFichaService;

        public FichasController(DbIntegradorContext context, InsertFichaService insertFichaService, ListFichaService listFichaService)
        {
            _context = context;
            _insertFichaService = insertFichaService;
            _listFichaService = listFichaService;
        }

        // GET: api/Fichas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListFichaDTO>>> GetFichas()
        {
            var fichas = await _listFichaService.ObtenerListadoFichasDoctoresUsuarios();

            if (fichas == null)
            {
                return NotFound();
            }

            return Ok(fichas);
        }

        // POST: api/Fichas
        [HttpPost]
        public async Task<ActionResult<Ficha>> PostFicha(InsertarFichaDTO fichaDTO)
        {
            try
            {
                var success = await _insertFichaService.InsertarFicha(fichaDTO);

                if (success)
                {
                    // Se insertó correctamente, retornar un mensaje de éxito
                    return Ok("Ficha creada exitosamente");
                }
                else
                {
                    // Hubo un error al insertar la ficha
                    return StatusCode(500, "Error al insertar la ficha.");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}

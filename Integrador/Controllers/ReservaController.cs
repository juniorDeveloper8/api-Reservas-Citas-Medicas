using Integrador.DTO.ReservaDTO;
using Integrador.Logica.ReservaServices;
using Integrador.Models;
using Integrador.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly DbIntegradorContext _context;
        //private readonly ListReservaXDNIService _reservasPorDNIService;
        private readonly ListReservasService _reservasService;
        private readonly InsertReservaService _insertReservaService;
        private readonly UpdateReservaService _updateReservaService;
        private readonly DeleteReservaService _deleteReservaService;

        public ReservaController(DbIntegradorContext context, ListReservasService reservasService, InsertReservaService insertReservaService, UpdateReservaService updateReservaService, DeleteReservaService deleteReservaService)
        {
            _context = context;
            _reservasService = reservasService;
            _insertReservaService = insertReservaService;
            _updateReservaService = updateReservaService;
            _deleteReservaService = deleteReservaService;
            //_reservasPorDNIService = reservasPorDNIService;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListReservasDTO>>> GetReservas()
        {
            var reservas = await _reservasService.ListarReservas();

            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }

        //// GET: api/Reserva/DNI/{dni}
        //[HttpGet("{dni}")]
        //public async Task<ActionResult<IEnumerable<ListarReservasPorDNIDTO>>> GetReservasPorDNI(int dni)
        //{
        //    var reservas = await _reservasPorDNIService.ListarReservasPorDNI(dni);

        //    if (reservas == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(reservas);
        //}


        // POST: api/Reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(InsertReservaDTO reservaDTO)
        {
            try
            {
                var success = await _insertReservaService.InsertarReserva(reservaDTO);
                if (success)
                {
                    // Se insertó correctamente, retornar el objeto creado
                    return Ok("Reserva creada exitosamente");
                }
                else
                {
                    // Hubo un error al insertar la reserva
                    return StatusCode(500, "Error al insertar la reserva.");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return StatusCode(500, "Error interno del servidor.");
            }
        }


        // PUT: api/Reserva
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, UpdateReservaDTO reservaDTO)
        {
            if (id != reservaDTO.Id)
            {
                return BadRequest();
            }

            // Verificar si la reserva a actualizar existe en la base de datos
            var reservaExists = await _context.Reservas.AnyAsync(r => r.Id == id);
            if (!reservaExists)
            {
                return NotFound();
            }

            // Actualizar la reserva utilizando el servicio
            var success = await _updateReservaService.ActualizarReserva(reservaDTO.Id, reservaDTO);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error al actualizar la reserva.");
            }
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var success = await _deleteReservaService.EliminarReserva(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

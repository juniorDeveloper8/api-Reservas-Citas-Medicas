using Integrador.DTO.ClincaDTO;
using Integrador.Logica.ClinicaService;
using Integrador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private readonly DbIntegradorContext _context;
        private readonly ListClinicaService _listClinicaService;
        private readonly UpdateClinicaService _updateClinicaService;
        private readonly InsertClinicaService _insertClinicaService;
        private readonly DeleteClinicaService _deleteClinicaService;

        public ClinicasController(DbIntegradorContext context,ListClinicaService listClinicaService, UpdateClinicaService updateClinicaService, InsertClinicaService insertClinicaService, DeleteClinicaService deleteClinicaService)
        {
            _context = context;
            _listClinicaService = listClinicaService;
            _updateClinicaService = updateClinicaService;
            _insertClinicaService = insertClinicaService;
            _deleteClinicaService = deleteClinicaService;
        }

        // GET: api/Clinicas
        [HttpGet]
        public IActionResult GetClinicas()
        {
            try
            {
                var clinicas = _listClinicaService.ListarClinicas();
                return Ok(clinicas); // Devuelve una respuesta HTTP 200 OK con el cuerpo de la respuesta que contiene las clínicas
            }
            catch (Exception ex)
            {
                // Maneja la excepción y devuelve una respuesta HTTP 500 Internal Server Error con un mensaje de error
                return StatusCode(500, $"Ocurrió un error al obtener las clínicas: {ex.Message}");
            }
        }

        // PUT: api/Clinica
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarClinica(ActualizarClinicaDTO clinicaDTO)
        {
            var exito = await _updateClinicaService.ActualizarClinica(clinicaDTO);
            if (exito)
            {
                return NoContent(); // Si la actualización es exitosa, devolver un código de estado 204 No Content
            }
            else
            {
                return StatusCode(500); // Si hay un error en la actualización, devolver un código de estado 500 Internal Server Error
            }
        }

        // POST: api/Clinica
        [HttpPost]
        public async Task<IActionResult> InsertarClinica(CrearClinicaDTO clinicaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exito = await _insertClinicaService.InsertarClinica(clinicaDTO);
            if (exito)
            {
                return Ok(); // Si la inserción es exitosa, devolver un código de estado 200 OK
            }
            else
            {
                return StatusCode(500); // Si hay un error en la inserción, devolver un código de estado 500 Internal Server Error
            }
        }

        // DELETE: api/Clinica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarClinica(int id)
        {
            var exito = await _deleteClinicaService.EliminarClinica(id);
            if (exito)
            {
                return NoContent(); // Si la eliminación es exitosa, devolver un código de estado 204 No Content
            }
            else
            {
                return NotFound(); // Si no se encuentra la clínica o hay un error en la eliminación, devolver un código de estado 404 Not Found
            }
        }
    }
}

using Integrador.DTO.especialidad;
using Integrador.Logica;
using Integrador.Logica.EspecialidadService;
using Integrador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadsController : ControllerBase
    {
        private readonly DbIntegradorContext _context;
        private readonly ListEspecialidadService _listEspecialidadService;
        private readonly InsertEspecialidadService _insertarEspecialidadService;
        private readonly UpdateEspecialidadService _actualizarEspecialidadesService;
        private readonly DeleteEspecialidadService _deleteEspecialidadService;

        public EspecialidadsController(DbIntegradorContext context, ListEspecialidadService listEspecialidadService, InsertEspecialidadService insertarEspecialidadService, UpdateEspecialidadService actualizarEspecialidadesService, DeleteEspecialidadService deleteEspecialidadService)
        {
            _context = context;
            _listEspecialidadService = listEspecialidadService;
            _insertarEspecialidadService = insertarEspecialidadService;
            _actualizarEspecialidadesService = actualizarEspecialidadesService;
            _deleteEspecialidadService = deleteEspecialidadService;
        }

        [HttpGet]
        public ActionResult<List<EspecialidadDTO>> GetEspecialidades()
        {
            try
            {
                var especialidades = _listEspecialidadService.ListarEspecialidadesAsync().Result; // Espera el resultado de forma síncrona

                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las especialidades: {ex.Message}");
            }
        }


        // POST: api/Especialidades
        [HttpPost]
        public async Task<ActionResult> PostEspecialidad(EspecialidadDTO especialidadDTO)
        {
            if (especialidadDTO == null)
            {
                return BadRequest("Los datos de la especialidad son nulos.");
            }

            try
            {
                var exito = await _insertarEspecialidadService.InsertarEspecialidad(especialidadDTO);
                if (exito)
                {
                    return Ok("La especialidad fue insertada correctamente.");
                }
                else
                {
                    return StatusCode(500, "Error al insertar la especialidad en la base de datos.");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        //actualizar
        [HttpPut]
        public async Task<IActionResult> ActualizarEspecialidad(int id, [FromBody] EspecialidadDTO especialidadDTO)
        {
            try
            {
                bool exito = await _actualizarEspecialidadesService.ActualizarEspecialidadAsync(id, especialidadDTO);
                if (exito)
                {
                    return Ok("La especialidad se actualizó correctamente.");
                }
                else
                {
                    return NotFound("La especialidad no se encontró.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        //delete
        [HttpDelete]
        public async Task<IActionResult> EliminarEspecialidad(int id)
        {
            try
            {
                await _deleteEspecialidadService.DeleteEspecialidadAsync(id);
                return Ok("La especialidad se eliminó correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
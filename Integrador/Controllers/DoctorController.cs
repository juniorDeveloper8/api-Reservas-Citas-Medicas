using Integrador.DTO.DoctorDTO;
using Integrador.Logica.DoctorService;
using Integrador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DbIntegradorContext _context;
        private readonly ListDoctorService _listDoctorService;
        private readonly InsertDoctorService _insertDoctor;
        private readonly UpdateDoctorService _updateDoctorService;
        private readonly DeleteDoctorService _deleteDoctorService;

        public DoctorController(DbIntegradorContext context, ListDoctorService listDoctorService, InsertDoctorService insertDoctor, UpdateDoctorService updateDoctorService, DeleteDoctorService deleteDoctorService)
        {
            _context = context;
            _listDoctorService = listDoctorService;
            _insertDoctor = insertDoctor;
            _updateDoctorService = updateDoctorService;
            _deleteDoctorService = deleteDoctorService;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctores()
        {
            var doctoresDTO = await _listDoctorService.ObtenerDoctores();
            if (doctoresDTO == null)
            {
                return NotFound();
            }
            return Ok(doctoresDTO);
        }
        // POST: api/Doctor
        [HttpPost]
        public async Task<ActionResult> InsertarDoctor(DoctorDTO doctorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exito = await _insertDoctor.InsertarDoctor(doctorDTO);
            if (exito)
            {
                return Ok(); // Si la inserción es exitosa, devolver un código de estado 200 OK
            }
            else
            {
                return StatusCode(500); // Si hay un error en la inserción, devolver un código de estado 500 Internal Server Error
            }
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDoctor(int id, GeneralDoctorDTO doctorDTO)
        {
            if (id != doctorDTO.Id)
            {
                return BadRequest();
            }

            var exito = await _updateDoctorService.ActualizarDoctor(doctorDTO);
            if (exito)
            {
                return NoContent(); // Si la actualización es exitosa, devolver un código de estado 204 No Content
            }
            else
            {
                return StatusCode(500); // Si hay un error en la actualización, devolver un código de estado 500 Internal Server Error
            }
        }
        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDoctor(int id)
        {
            var exito = await _deleteDoctorService.EliminarDoctor(new DeleteDoctorDTO { Id = id });
            if (exito)
            {
                return NoContent(); // Si la eliminación es exitosa, devolver un código de estado 204 No Content
            }
            else
            {
                return StatusCode(500); // Si hay un error en la eliminación, devolver un código de estado 500 Internal Server Error
            }
        }
    }
}

using Integrador.DTO.UserDTO;
using Integrador.Logica.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly InsertUserService _insertUserService;
        private readonly UpdateUserService _updateUserService;

        public UserController(UserServices userServices, InsertUserService insertUserService, UpdateUserService updateUserService)
        {
            _userServices = userServices;
            _insertUserService = insertUserService;
            _updateUserService = updateUserService;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralUserDTO>>> ListarUsuarios()
        {
            var usuarios = await _userServices.ListarUsuarios();

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound("No se encontraron usuarios.");
            }

            return Ok(usuarios);
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralUserDTO>> GetUserById(int id)
        {
            var usuario = _userServices.GetUserById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // buscar usuario por cedula o nombre
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<GeneralUserDTO>>> GetUsersByNameAndIdNumber(string nombre, string cedula)
        {
            var usuarios = _userServices.GetUsersByNameAndIdNumber(nombre, cedula);
            return Ok(usuarios);
        }
        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult> InsertarUsuario(GeneralUserDTO usuarioDTO)
        {
            var exito = await _insertUserService.InsertarUsuario(usuarioDTO);
            if (exito)
            {
                return Ok("Usuario insertado correctamente.");
            }
            else
            {
                return StatusCode(500, "Error al insertar usuario.");
            }
        }
        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, USerDTOID usuarioDTO)
        {
            var resultado = await _updateUserService.ActualizarUsuario(id, usuarioDTO);
            if (resultado == "Success")
            {
                return Ok("Usuario actualizado correctamente.");
            }
            else
            {
                return StatusCode(500, resultado);
            }
        }
    }
}

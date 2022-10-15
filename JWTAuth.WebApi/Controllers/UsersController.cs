using JWTAuth.WebApi.DTOs;
using JWTAuth.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(Guid id)
        {
            var userDTO = _usersService.GetUser(id);
            return Ok(userDTO);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var usersDTO = _usersService.GetUsers();
            return Ok(usersDTO);
        }

        [HttpPost("Create")]
        public IActionResult Create(UserDTO userDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var id = _usersService.CreateUser(userDTO);
            return CreatedAtAction(nameof(Get), new { id = id }, userDTO);
        }
    }
}
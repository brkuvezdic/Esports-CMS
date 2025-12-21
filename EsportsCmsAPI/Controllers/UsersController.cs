using EsportsCmsApplication.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using EsportsCmsApplication.Interfaces.Users;
namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUsersService _service;


        public UsersController(IUsersService service)
        {
            _service = service;

        }

        // GET: api/users
        [HttpGet(Name = "GetAllStudents")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var users = await _service.GetAllStudentsAsync();
            return Ok(users);
        }

    }
}



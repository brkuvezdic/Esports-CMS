using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.DTOs.EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Users;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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

        // POST: api/users/assign-college
        [HttpPost("assign-college")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignStudentToCollegeAsync(
            [FromBody] AssignUserToCollegeDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request.");

            var success = await _service.AssignStudentToCollegeAsync(dto);

            if (!success)
                return NotFound("User or College not found.");

            return Ok(new { message = "Student assigned to college successfully." });
        }

        // POST: api/users/remove-college
        [HttpPost("remove-college")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveStudentFromCollegeAsync(
        [FromBody] RemoveUserFromCollegeDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request");

            var success = await _service.RemoveStudentFromCollegeAsync(dto);

            if (!success)
                return NotFound("User not found");

            return Ok(new { message = "Student removed from college successfully." });
        }

        [HttpPost("join-team")]
        public async Task<IActionResult> JoinTeam(
    JoinTeamDto dto)
        {
            var result = await _service.JoinTeamAsync(dto);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpPost("leave-team")]
        public async Task<IActionResult> LeaveTeam(
            LeaveTeamDto dto)
        {
            var result = await _service.LeaveTeamAsync(dto);

            if (!result)
                return BadRequest();

            return Ok();
        }

    }
}



using EsportsCmsApplication.Interfaces.Teams;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAllTeams")]
        public async Task<IActionResult> GetAllTeamsAsync()
        {
            var teams = await _service.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("MyTeams")]
        public async Task<IActionResult> GetMyTeams()
        {
            var collegeIdClaim = User.FindFirst("CollegeId")?.Value;

            if (collegeIdClaim == null)
                return Unauthorized();

            int collegeId = int.Parse(collegeIdClaim);

            var teams = await _service.GetTeamsByCollegeIdAsync(collegeId);

            return Ok(teams);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTeamsForUser(Guid userId)
        {
            var teams = await _service.GetTeamsForUserAsync(userId);
            return Ok(teams);
        }
    }
}
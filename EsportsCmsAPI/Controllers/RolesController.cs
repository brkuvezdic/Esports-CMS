using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Interfaces.Roles;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;


        public RolesController(IRoleService service)
        {
            _service = service;
        }

        // GET: api/roles
        [HttpGet(Name = "GetAllRoles")]
        [ProducesResponseType(typeof(IEnumerable<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var colleges = await _service.GetAllRolesAsync();
            return Ok(colleges);
        }
    }
}

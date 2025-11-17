using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly ICollegeService _service;

        public CollegesController(ICollegeService service)
        {
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CollegeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status500InternalServerError)]
        [ProducesResponseType( StatusCodes.Status401Unauthorized)]
        [ProducesResponseType( StatusCodes.Status403Forbidden)]

        public async Task<IActionResult> GetAllCollegesAsync()
        {
            var colleges = await _service.GetAllCollegesAsync();
            return Ok(colleges);


        }
    }


}


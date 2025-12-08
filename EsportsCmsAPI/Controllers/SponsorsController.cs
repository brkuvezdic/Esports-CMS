using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Sponsors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        private readonly ISponsorService _service;

        public SponsorsController(
            ISponsorService service)
        {
            _service = service;
        }

        // GET: api/sponsors
        [HttpGet(Name = "GetAllSponsors")]
        [ProducesResponseType(typeof(IEnumerable<SponsorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSponsorsAsync()
        {
            var sponsors = await _service.GetAllSponsorsAsync();
            return Ok(sponsors);
        }
    }
}

using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.PandaScore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EsportsCmsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PandaScoreController : ControllerBase
    {
        private readonly IPandaScoreService _pandaScoreService;

        public PandaScoreController(IPandaScoreService pandaScoreService)
        {
            _pandaScoreService = pandaScoreService;
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<List<PandaScoreMatchDto>>> GetUpcomingMatches()
        {
            var matches = await _pandaScoreService.GetUpcomingMatchesAsync();
            return Ok(matches);
        }
    }
}

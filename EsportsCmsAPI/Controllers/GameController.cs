using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Games;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAllGames")]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _service.GetAllGamesAsync();
            return Ok(games);
        }
    }



}

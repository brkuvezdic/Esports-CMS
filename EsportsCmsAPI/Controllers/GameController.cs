using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICollegeService _service;
        //private readonly IValidator<CreateCollegeDto> createCollegeValidator;
        //private readonly IValidator<UpdateCollegeDto> updateCollegeValidator;


        public GameController(ICollegeService service /*IValidator<CreateCollegeDto> createCollegeValidator, IValidator<UpdateCollegeDto> updateCollegeValidator*/)
        {
            _service = service;
            //this.createCollegeValidator = createCollegeValidator;
            //this.updateCollegeValidator = updateCollegeValidator;
        }

        //// GET: api/games
        //[HttpGet(Name = "GetAllGames")]
        //[ProducesResponseType(typeof(IEnumerable<GameDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetAllGamesAsync()
        //{
        //    var colleges = await _service.GetAllGamesAsync();
        //    return Ok(colleges);
        //}


    }



}

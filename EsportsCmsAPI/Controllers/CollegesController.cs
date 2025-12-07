using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.DTOValidations;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsInfrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly ICollegeService _service;
        private readonly IValidator<CreateCollegeDto> createCollegeValidator;
        private readonly IValidator<UpdateCollegeDto> updateCollegeValidator;

        public CollegesController(ICollegeService service, IValidator<CreateCollegeDto> createCollegeValidator, IValidator<UpdateCollegeDto> updateCollegeValidator)
        {
            _service = service;
            this.createCollegeValidator = createCollegeValidator;
            this.updateCollegeValidator = updateCollegeValidator;
        }

        // GET: api/colleges
        [HttpGet(Name = "GetAllColleges")]
        [ProducesResponseType(typeof(IEnumerable<CollegeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCollegesAsync()
        {
            var colleges = await _service.GetAllCollegesAsync();
            return Ok(colleges);
        }

        // GET: api/colleges/5
        [HttpGet("{id:int}", Name = "GetCollegeById")]
        [ProducesResponseType(typeof(CollegeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollegeByIdAsync(int id)
        {
            var college = await _service.GetCollegeByIdAsync(id);
            return Ok(college);
        }

        // POST: api/colleges
        [HttpPost(Name = "CreateCollege")]
        [ProducesResponseType(typeof(CollegeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCollegeAsync([FromBody] CreateCollegeDto dto)
        {
            var validationResult = await createCollegeValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var created = await _service.CreateCollegeAsync(dto);

            return CreatedAtRoute("GetCollegeById", new { id = created.CollegeId }, created);
        }

        // PUT: api/colleges
        [HttpPut(Name = "UpdateCollege")]
        [ProducesResponseType(typeof(CollegeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCollegeAsync([FromBody] UpdateCollegeDto dto)
        {
            var validationResult = await updateCollegeValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var updated = await _service.UpdateCollegeAsync(dto);
            return Ok(updated);
        }

        // PATCH: api/colleges/description
        [HttpPatch("description", Name = "UpdateCollegeDescription")]
        [ProducesResponseType(typeof(CollegeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCollegeDescriptionAsync([FromBody] UpdateCollegeDescriptionDto dto)
        {
            var updated = await _service.UpdateCollegeDescriptionAsync(dto);
            return Ok(updated);
        }

        // DELETE: api/colleges/5
        [HttpDelete("{id:int}", Name = "DeleteCollege")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCollegeAsync(int id)
        {
            var deleted = await _service.DeleteCollegeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }




        [HttpPost("reorder")]
        public async Task<IActionResult> ReorderColleges([FromBody] List<ReorderCollegeDto> reordered)
        {
            if (reordered == null || !reordered.Any())
                return BadRequest("Invalid reorder list");

            await _service.ReorderCollegesAsync(reordered);
            return Ok();
        }

    }
}

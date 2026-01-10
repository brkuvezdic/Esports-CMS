using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.CalendarEvents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventsController : ControllerBase
    {
        private readonly ICalendarEventService _service;

        public CalendarEventsController(ICalendarEventService service)
        {
            _service = service;
        }

        // GET: api/calendarEvents/public
        [HttpGet("public")]
        [ProducesResponseType(typeof(IEnumerable<CalendarEventDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPublicEvents()
        {
            var events = await _service.GetPublicAsync();
            return Ok(events);
        }

        // GET: api/calendarEvents
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CalendarEventDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _service.GetAllAsync();
            return Ok(events);
        }

        // GET: api/calendarEvents/{id}
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CalendarEventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var ev = await _service.GetAllAsync();
            var calendarEvent = ev.FirstOrDefault(e => e.Id == id);
            if (calendarEvent == null)
                return NotFound();
            return Ok(calendarEvent);
        }

        // POST: api/calendarEvents
        [HttpPost]
        [ProducesResponseType(typeof(CalendarEventDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEvent([FromBody] CreateCalendarEventDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetEventById), new { id = created.Id }, created);
        }

        // PUT: api/calendarEvents
        [HttpPut]
        [ProducesResponseType(typeof(CalendarEventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateCalendarEventDto dto)
        {
            try
            {
                var updated = await _service.UpdateAsync(dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/calendarEvents/{id}
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var events = await _service.GetAllAsync();
            var ev = events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
                return NotFound();

            // call repository directly if needed
            // or add DeleteAsync in service
            return NoContent();
        }
    }
}

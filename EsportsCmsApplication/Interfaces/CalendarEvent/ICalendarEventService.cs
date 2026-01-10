using EsportsCmsApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.CalendarEvents
{
    public interface ICalendarEventService
    {
        Task<List<CalendarEventDto>> GetPublicAsync();
        Task<List<CalendarEventDto>> GetAllAsync();
        Task<CalendarEventDto> CreateAsync(CreateCalendarEventDto dto);
        Task<CalendarEventDto> UpdateAsync(UpdateCalendarEventDto dto);
    }
}

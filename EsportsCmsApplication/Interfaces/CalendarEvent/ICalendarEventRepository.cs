using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportsCmsDomain.EntitiesNew;


namespace EsportsCmsApplication.Interfaces.CalendarEvents
{
    public interface ICalendarEventRepository
    {
        Task<List<CalendarEvent>> GetAllAsync();
        Task<List<CalendarEvent>> GetPublishedAsync();
        Task<CalendarEvent?> GetByIdAsync(Guid id);
        Task<CalendarEvent> AddAsync(CalendarEvent ev);
        Task<CalendarEvent> UpdateAsync(CalendarEvent ev);
        Task DeleteAsync(CalendarEvent ev);
    }
}

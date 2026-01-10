using EsportsCmsApplication.Interfaces.CalendarEvents;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class CalendarEventRepository : ICalendarEventRepository
    {
        private readonly EsportsCmsContext _db;

        public CalendarEventRepository(EsportsCmsContext db)
        {
            _db = db;
        }

        public Task<List<CalendarEvent>> GetAllAsync()
            => _db.CalendarEvents.OrderBy(e => e.StartDate).ToListAsync();

        public Task<List<CalendarEvent>> GetPublishedAsync()
            => _db.CalendarEvents
                .Where(e => e.IsPublished)
                .OrderBy(e => e.StartDate)
                .ToListAsync();

        public async Task<CalendarEvent?> GetByIdAsync(Guid id)
            => await _db.CalendarEvents.FindAsync(id);

        public async Task<CalendarEvent> AddAsync(CalendarEvent ev)
        {
            _db.CalendarEvents.Add(ev);
            await _db.SaveChangesAsync();
            return ev;
        }

        public async Task<CalendarEvent> UpdateAsync(CalendarEvent ev)
        {
            _db.CalendarEvents.Update(ev);
            await _db.SaveChangesAsync();
            return ev;
        }

        public async Task DeleteAsync(CalendarEvent ev)
        {
            _db.CalendarEvents.Remove(ev);
            await _db.SaveChangesAsync();
        }
    }

}
